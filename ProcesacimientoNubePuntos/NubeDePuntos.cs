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

        public int size { get => this.Puntos.Count; }

        public void AddPunto(Punto punto)
        {
            Puntos.Add(punto);
        }

    }
}
