using System;
using System.Collections.Generic;
using System.Text;

namespace ProcesacimientoNubePuntos
{
    class CampoVoxeles
    {
        public CampoVoxeles(NubeDePuntos nube, float ladoVoxel)
        {
            this.Nube = nube;
            this.LadoVoxel = ladoVoxel;
            voxeles.Clear();

        }

        public NubeDePuntos Nube{ get; set; }

        public float LadoVoxel { get; set; }
        public float CentroVoxelInicialX
        {
            get { return Nube.MinX + LadoVoxel / 2; }
        }

        public float CentroVoxelInicialY
        {
            get { return Nube.MinY + LadoVoxel / 2; }
        }

        public float CentroVoxelInicialZ
        {
            get { return Nube.MinZ + LadoVoxel / 2; }
        }

        public List<Voxel> voxeles = new List<Voxel>();

        void GenerarNube()
        {

        }
    }
}
