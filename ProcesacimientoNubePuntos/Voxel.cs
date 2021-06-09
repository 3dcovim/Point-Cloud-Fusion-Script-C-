using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace ProcesacimientoNubePuntos
{
    class Voxel
    {
        public Voxel(Vector3 centro, float lado)
        {
            this.Centro = centro;
            this.Lado = lado;
            Puntos.Clear();
        }
        public float Lado
        {
            get;set;
        }

        public Vector3 Centro
        {
            get;set;
        }

        public List<Punto> Puntos = new List<Punto>();

    }
}
