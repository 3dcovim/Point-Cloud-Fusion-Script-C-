﻿using System;
using System.Globalization;
using System.IO;
using System.Numerics;
using Octree;
using System.Linq;

namespace ProcesacimientoNubePuntos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¿Cuál es la ruta del archivo .txt con la nube de puntos?");
            string rutaTxt = Console.ReadLine(); //C:\Users\3DCOVIM-Station 2\Documents\Desarrollo\Nubes de puntos\Scripts MatLab\NubeSuma - Cloud.txt
            Console.WriteLine($"La ruta del .txt es {rutaTxt}");

            string[] lines = File.ReadAllLines(rutaTxt);

            NubeDePuntos nubeDePuntos = new NubeDePuntos();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] componentes = lines[i].Split(' ');

                float x = float.Parse(componentes[0], CultureInfo.InvariantCulture);
                //Console.WriteLine("X vale: " + x);
                float y = float.Parse(componentes[1], CultureInfo.InvariantCulture);
                float z = float.Parse(componentes[2], CultureInfo.InvariantCulture);
                float temp = float.Parse(componentes[3], CultureInfo.InvariantCulture);
                int index = (int)float.Parse(componentes[4], CultureInfo.InvariantCulture);

                Punto punto = new Punto(new Vector3(x, y, z), temp, index);
                nubeDePuntos.AddPunto(punto);
            }

            Console.WriteLine($"La nube de puntos tiene {nubeDePuntos.size} puntos");
            Console.WriteLine($"El valor máximo de X es: {nubeDePuntos.MaxX} y el mínimo: {nubeDePuntos.MinX}");
            Console.WriteLine($"El valor máximo de X es: {nubeDePuntos.MaxY} y el mínimo: {nubeDePuntos.MinY}");
            Console.WriteLine($"El valor máximo de X es: {nubeDePuntos.MaxZ} y el mínimo: {nubeDePuntos.MinZ}");


            Console.WriteLine("¿Cuanto quieres que mida el lado del Voxel?");
            float ladoVoxel = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            int cantVoxelesX = Convert.ToInt32(Math.Ceiling(nubeDePuntos.LongX / ladoVoxel));
            int cantVoxelesY = Convert.ToInt32(Math.Ceiling(nubeDePuntos.LongY / ladoVoxel));
            int cantVoxelesZ = Convert.ToInt32(Math.Ceiling(nubeDePuntos.LongZ / ladoVoxel));
            Console.WriteLine($"El numero de voxeles en el eje X es: {cantVoxelesX}");
            Console.WriteLine($"El numero de voxeles en el eje Y es: {cantVoxelesY}");
            Console.WriteLine($"El numero de voxeles en el eje Z es: {cantVoxelesZ}");

            Console.WriteLine($"Total vóxeles: {cantVoxelesX * cantVoxelesY * cantVoxelesZ}");


            CampoVoxeles campoVoxeles = new CampoVoxeles(nubeDePuntos, ladoVoxel);

            float[] longitudes = { nubeDePuntos.LongX, nubeDePuntos.LongY, nubeDePuntos.LongZ };
            float initialWorldSize = longitudes.Max();
            Point initialWorldPosition = new Point(nubeDePuntos.MinX + (nubeDePuntos.LongX / 2), nubeDePuntos.MinY + (nubeDePuntos.LongY / 2), nubeDePuntos.MinZ + (nubeDePuntos.LongZ / 2));
            PointOctree<Voxel> octree = new PointOctree<Voxel>(initialWorldSize, initialWorldPosition, 0.2f);

            //int indiceForEach = 0;
            foreach (Punto punto in nubeDePuntos.Puntos)
            {
                //Obtención del centro del Voxel al que pertecene cada punto
                float centroVoxelX = (float)Math.Floor((punto.Location.X - nubeDePuntos.MinX) / campoVoxeles.LadoVoxel) * campoVoxeles.LadoVoxel + campoVoxeles.CentroVoxelInicialX;
                float centroVoxelY = (float)Math.Floor((punto.Location.Y - nubeDePuntos.MinY) / campoVoxeles.LadoVoxel) * campoVoxeles.LadoVoxel + campoVoxeles.CentroVoxelInicialY;
                float centroVoxelZ = (float)Math.Floor((punto.Location.Z - nubeDePuntos.MinZ) / campoVoxeles.LadoVoxel) * campoVoxeles.LadoVoxel + campoVoxeles.CentroVoxelInicialZ;
                Vector3 centroVoxelPunto = new Vector3(centroVoxelX, centroVoxelY, centroVoxelZ);

                Voxel[] voxelesObjetivo = octree.GetNearby(new Point(centroVoxelX, centroVoxelY, centroVoxelZ), ladoVoxel);

                bool voxelExiste = false;
                if (voxelesObjetivo.Length != 0)
                {
                    foreach (Voxel voxel in voxelesObjetivo)
                    {
                        if (voxel.Centro == centroVoxelPunto)
                        {
                            voxel.Puntos.Add(punto);//añadir punto al voxel
                            voxelExiste = true;
                            break;
                        }
                    }
                }
                
                if (!voxelExiste)
                {
                    Voxel nuevoVoxel = new Voxel(centroVoxelPunto, ladoVoxel);
                    campoVoxeles.voxeles.Add(nuevoVoxel);
                    octree.Add(nuevoVoxel, new Point(nuevoVoxel.Centro.X, nuevoVoxel.Centro.Y, nuevoVoxel.Centro.Z));
                    nuevoVoxel.Puntos.Add(punto);
                }
                //Console.WriteLine(indiceForEach++);
            }

            campoVoxeles.GenerarNube();
            Console.WriteLine("Nube creada");

            Console.ReadKey();

        }
    }
}
