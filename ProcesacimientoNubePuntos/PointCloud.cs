using System;
using System.Collections.Generic;
using System.Text;

namespace PointCloudProcessing
{
    class PointCloud
    {

        public PointCloud()
        {

        }
        public PointCloud(Point[] points)
        {
            this.Points.Clear();
            for(int i = 0; i < points.Length; i++)
            {
                this.Points.Add(points[i]);
            }
        }

        public PointCloud(List<Point> points)
        {
            this.Points = points;
        }


        public List<Point> Points = new List<Point>();

        private float m_minX = float.MaxValue;
        public float MinX
        {
            get
            {
                if (m_minX == float.MaxValue)
                {
                    foreach (Point punto in Points)
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
                foreach (Point point in Points)
                {
                    if (point.Location.Y < m_minY)
                        m_minY = point.Location.Y;
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
                    foreach (Point point in Points)
                    {
                        if (point.Location.Z < m_minZ)
                            m_minZ = point.Location.Z;
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
                    foreach (Point point in Points)
                    {
                        if (point.Location.X > m_maxX)
                            m_maxX = point.Location.X;
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
                    foreach (Point point in Points)
                    {
                        if (point.Location.Y > m_maxY)
                            m_maxY = point.Location.Y;
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
                    foreach (Point point in Points)
                    {
                        if (point.Location.Z > m_maxZ)
                            m_maxZ = point.Location.Z;
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


        public int size { get => this.Points.Count; }

        public void AddPunto(Point point)
        {
            Points.Add(point);
        }

    }
}
