using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PointCloudProcessing
{
    class VoxelField
    {
        public VoxelField(PointCloud nube, float ladoVoxel)
        {
            this.Nube = nube;
            this.LadoVoxel = ladoVoxel;
            voxeles.Clear();

        }

        public PointCloud Nube{ get; set; }

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

        public void GenerateCloud()
        {
            Console.WriteLine("File where the point cloud will be stored (withot .txt) :");
            string fileName = Console.ReadLine();
            string path = @"d:\nub\" + fileName+ ".txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("X Y Z T1 T2 T3 T4 T5 T6");
                foreach(Voxel voxel in voxeles)
                {
                    float temp1 = 0; //Value for the mean of the temperature of the points of cloud 1 that are in the Voxel.
                    float temp2 = 0;
                    float temp3 = 0;
                    float temp4 = 0;
                    float temp5 = 0;
                    float temp6 = 0;
                    int Cloud1counter = 0; //Count the number of points of cloud 1 in the Voxel.
                    int Cloud2counter = 0;
                    int Cloud3counter = 0;
                    int Cloud4counter = 0;
                    int Cloud5counter = 0;
                    int Cloud6counter = 0;

                    foreach (Point point in voxel.Points)
                    {
                        if (!float.IsNaN(point.Temperature))
                        {
                            if (point.IndexCloud == 0)
                            {
                                temp1 = point.Temperature + temp1;
                                Cloud1counter++;
                            }
                            else if (point.IndexCloud == 1)
                            {
                                temp2 = point.Temperature + temp2;
                                Cloud2counter++;
                            }
                            else if (point.IndexCloud == 2)
                            {
                                temp3 = point.Temperature + temp3;
                                Cloud3counter++;
                            }
                            else if (point.IndexCloud == 3)
                            {
                                temp4 = point.Temperature + temp4;
                                Cloud4counter++;
                            }
                            else if (point.IndexCloud == 4)
                            {
                                temp5 = point.Temperature + temp5;
                                Cloud5counter++;
                            }
                            else if (point.IndexCloud == 5)
                            {
                                temp6 = point.Temperature + temp6;
                                Cloud6counter++;
                            }
                        }
                        

                    }
   
                    temp1 = Cloud1counter == 0 ? float.NaN : temp1 / Cloud1counter;
                    temp2 = Cloud2counter == 0 ? float.NaN : temp2 / Cloud2counter;
                    temp3 = Cloud3counter == 0 ? float.NaN : temp3 / Cloud3counter;
                    temp4 = Cloud4counter == 0 ? float.NaN : temp4 / Cloud4counter;
                    temp5 = Cloud5counter == 0 ? float.NaN : temp5 / Cloud5counter;
                    temp6 = Cloud6counter == 0 ? float.NaN : temp6 / Cloud6counter;

                    sw.WriteLine($"{voxel.Center.X} {voxel.Center.Y} {voxel.Center.Z} {temp1} {temp2} {temp3} {temp4} {temp5} {temp6}");
                    //}
                }
            }
            Console.WriteLine("Resulting point cloud saved!");
            Console.WriteLine($"Point cloud has {voxeles.Count} points.");
        }
    }
}
