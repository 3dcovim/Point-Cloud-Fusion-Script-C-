using System;
using System.Collections.Generic;
using System.Text;

namespace ProcesacimientoNubePuntos
{
    class NubeDePuntos
    {

        public NubeDePuntos()
        {

        }
        public NubeDePuntos(Punto[] puntos)
        {
            this.Puntos.Clear();
            for(int i = 0; i < puntos.Length; i++)
            {
                this.Puntos.Add(puntos[i]);
            }
        }

        public NubeDePuntos(List<Punto> puntos)
        {
            this.Puntos = puntos;
        }


        public List<Punto> Puntos = new List<Punto>();

         public float MinX
        {
            get
            {
                float minX = float.MaxValue;
                foreach (Punto punto in Puntos)
                {
                    if (punto.Location.X < minX)
                        minX = punto.Location.X;
                }
                return minX;
            }
        }

        public float MinY
        {
            get
            {
                float minY = float.MaxValue;
                foreach (Punto punto in Puntos)
                {
                    if (punto.Location.Y < minY)
                        minY = punto.Location.Y;
                }
                return minY;
            }
        }

        public float MinZ
        {
            get
            {
                float minZ = float.MaxValue;
                foreach (Punto punto in Puntos)
                {
                    if (punto.Location.Z < minZ)
                        minZ = punto.Location.Z;
                }
                return minZ;
            }
        }


        public float MaxX
        {
            get
            {
                float maxX = float.MinValue;
                foreach (Punto punto in Puntos)
                {
                    if (punto.Location.X > maxX)
                        maxX = punto.Location.X;
                }
                return maxX;
            }
        }

        public float MaxY
        {
            get
            {
                float maxY = float.MinValue;
                foreach (Punto punto in Puntos)
                {
                    if (punto.Location.Y > maxY)
                        maxY = punto.Location.Y;
                }
                return maxY;
            }
        }

        public float MaxZ
        {
            get
            {
                float maxZ = float.MinValue;
                foreach (Punto punto in Puntos)
                {
                    if (punto.Location.Z > maxZ)
                        maxZ = punto.Location.Z;
                }
                return maxZ;
            }
        }



        public int size { get => this.Puntos.Count; }

        public void AddPunto(Punto punto)
        {
            Puntos.Add(punto);
        }

    }
}
