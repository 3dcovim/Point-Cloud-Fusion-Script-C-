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

        private float m_minX = float.MaxValue;
        public float MinX
        {
            get
            {
                if (m_minX == float.MaxValue)
                {
                    foreach (Punto punto in Puntos)
                    {
                        if (punto.Location.X < m_minX)
                            m_minX = punto.Location.X;
                    }
                }
                return m_minX;
            }
            set
            {
                if (value < m_minX)
                    m_minX = value;
            }
        }

        private float m_minY = float.MaxValue;
        public float MinY
        {
            get
            {
                if(m_minY == float.MaxValue)
                {
                foreach (Punto punto in Puntos)
                {
                    if (punto.Location.Y < m_minY)
                        m_minY = punto.Location.Y;
                }
                }
                return m_minY;
            }
            set
            {
                if (value < m_minY)
                    m_minY = value;
            }
        }
        private float m_minZ = float.MaxValue;
        public float MinZ
        {
            get
            {
                if (m_minZ == float.MaxValue)
                {
                    foreach (Punto punto in Puntos)
                    {
                        if (punto.Location.Z < m_minZ)
                            m_minZ = punto.Location.Z;
                    }
                }
                return m_minZ;
            }
            set
            {
                if (value < m_minZ)
                    m_minZ = value;
            }
        }

        private float m_maxX = float.MinValue;
        public float MaxX
        {
            get
            {
                if (m_maxX == float.MinValue)
                {
                    foreach (Punto punto in Puntos)
                    {
                        if (punto.Location.X > m_maxX)
                            m_maxX = punto.Location.X;
                    }
                }
                return m_maxX;
            }
            set
            {
                if (value > m_maxX)
                    m_maxX = value;
            }
        }
        private float m_maxY = float.MinValue;
        public float MaxY
        {
            get
            {
                if (m_maxY == float.MinValue)
{
                    foreach (Punto punto in Puntos)
                    {
                        if (punto.Location.Y > m_maxY)
                            m_maxY = punto.Location.Y;
                    }
                }
                return m_maxY;
            }
            set
            {
                if (value > m_maxY)
                    m_maxY = value;
            }
        }
        private float m_maxZ = float.MinValue;
        public float MaxZ
        {
            get
            {
                if (m_maxZ == float.MinValue)
                {
                    foreach (Punto punto in Puntos)
                    {
                        if (punto.Location.Z > m_maxZ)
                            m_maxZ = punto.Location.Z;
                    }
                }
                return m_maxZ;
            }
            set
            {
                if (value > m_maxZ)
                    m_maxZ = value;
            }
        }

        public float LongX
        {
            get { return m_maxX - m_minX; }
        }

        public float LongY
        {
            get { return m_maxY - m_minY; }
        }

        public float LongZ
        {
            get { return m_maxZ - m_minZ; }
        }


        public int size { get => this.Puntos.Count; }

        public void AddPunto(Punto punto)
        {
            Puntos.Add(punto);
        }

    }
}
