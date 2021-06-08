using System;
using System.Globalization;
using System.IO;
using System.Numerics;

namespace ProcesacimientoNubePuntos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¿Cuál es la ruta del archivo .txt con la nube de puntos?");
            string rutaTxt = Console.ReadLine();
            Console.WriteLine($"La ruta del .txt es {rutaTxt}");

            string[] lines = File.ReadAllLines(rutaTxt);

            NubeDePuntos nubeDePuntos = new NubeDePuntos();

            for(int i = 1; i < lines.Length; i++)
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

            Console.ReadKey();

        }
    }
}
