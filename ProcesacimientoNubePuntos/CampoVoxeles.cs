using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProcesacimientoNubePuntos
{
    class CampoVoxeles
    {
        public CampoVoxeles(NubeDePuntos nube, float ladoVoxel)
        {
            this.Nube = nube;
            this.LadoVoxel = ladoVoxel;
            voxeles.Clear();

        }

        public NubeDePuntos Nube{ get; set; }

        public float LadoVoxel { get; set; }
        public float CentroVoxelInicialX
        {
            get { return Nube.MinX + LadoVoxel / 2; }
        }

        public float CentroVoxelInicialY
        {
            get { return Nube.MinY + LadoVoxel / 2; }
        }

        public float CentroVoxelInicialZ
        {
            get { return Nube.MinZ + LadoVoxel / 2; }
        }

        public List<Voxel> voxeles = new List<Voxel>();

        public void GenerarNube()
        {
            string path = @"C:\Users\3DCOVIM-Station 2\Documents\Desarrollo\Nubes de puntos\Scripts MatLab\NubeScriptSamuel.txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("X, Y, Z");
                foreach(Voxel voxel in voxeles)
                {
                    float temp1 = 0;
                    float temp2 = 0;
                    float temp3 = 0;
                    int contadorPuntosNube1 = 0;
                    int contadorPuntosNube2 = 0;
                    int contadorPuntosNube3 = 0;

                    foreach (Punto punto in voxel.Puntos)
                    {
                        if (punto.IndexNube == 0)
                        {
                            temp1 = punto.Temperatura + temp1;
                            contadorPuntosNube1++;
                        }
                        else if(punto.IndexNube == 1)
                        {
                            temp2 = punto.Temperatura + temp2;
                            contadorPuntosNube2++;
                        }
                        else if (punto.IndexNube == 2)
                        {
                            temp3 = punto.Temperatura + temp3;
                            contadorPuntosNube3++;
                        }
                    }
                    temp1 = temp1 / contadorPuntosNube1;
                    temp2 = temp2 / contadorPuntosNube2;
                    temp3 = temp3 / contadorPuntosNube3;


                    sw.WriteLine($"{voxel.Centro.X} {voxel.Centro.Y} {voxel.Centro.Z} {temp1} {temp2} {temp3}");
                }
            }
        }
    }
}
