using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text;

namespace PointCloudProcessing
{
    class Point
    {
        public Point (Vector3 location, float temperature, int index)
        {
            m_location = location;
            Temperature = temperature;
            IndexCloud = index;
        }

        Vector3 m_location;

        public Vector3 Location //X, Y, Z position of point
        {
            get { return m_location; }
            set { m_location = value; }
        }


        public int IndexCloud { get; set; } //Index of the belonging point cloud

        public float Temperature { get; set; } // Point Temperature

    }
}
