using System;
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

                float x = float.Parse(componentes[0]);
                float y = float.Parse(componentes[1]);
                float z = float.Parse(componentes[2]);
                float temp = float.Parse(componentes[3]);
                int index = (int)float.Parse(componentes[4]);

                Punto punto = new Punto(new Vector3(x, y, z), temp, index);
                nubeDePuntos.AddPunto(punto);
            }

            Console.WriteLine($"La nube de puntos tiene {nubeDePuntos.size} puntos");
            Console.ReadKey();

        }
    }
}
