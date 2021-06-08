using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text;

namespace ProcesacimientoNubePuntos
{
    class Punto
    {
        public Punto (Vector3 location, float temperatura, int index)
        {
            m_location = location;
            Temperatura = temperatura;
            IndexNube = index;
        }

        Vector3 m_location;

        public Vector3 Location 
        {
            get { return m_location; }
            set { m_location = value; }
        }

        public int IndexNube { get; set; }

        public float Temperatura { get; set; }

    }
}
