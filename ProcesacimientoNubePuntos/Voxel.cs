using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace PointCloudProcessing
{
    class Voxel
    {
        public Voxel(Vector3 center, float side)
        {
            this.Center = center;
            this.Side = side;
            Points.Clear();
        }
        public float Side
        {
            get;set;
        }

        public Vector3 Center
        {
            get;set;
        }

        public List<Point> Points = new List<Point>();

    }
}
