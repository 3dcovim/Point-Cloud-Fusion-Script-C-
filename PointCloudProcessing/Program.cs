using System;
using System.Globalization;
using System.IO;
using System.Numerics;
using Octree;
using System.Linq;

namespace PointCloudProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which is the path of the point cloud file (.txt)?");
            string pathTxt = Console.ReadLine(); //C:\Users\3DCOVIM-Station 2\Documents\Desarrollo\Nubes de puntos\Scripts MatLab\NubeSuma - Cloud.txt
            Console.WriteLine($"The .txt path is {pathTxt}");

            string[] lines = File.ReadAllLines(pathTxt);

            PointCloud pointCloud = new PointCloud();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] components = lines[i].Split(' '); //Divide the txt lines into strings, delimiter = white space
                try
                {
                    float x = float.Parse(components[0], CultureInfo.InvariantCulture); //CultureInfo.InvariantCulture : using . for decimal
                    float y = float.Parse(components[1], CultureInfo.InvariantCulture);
                    float z = float.Parse(components[2], CultureInfo.InvariantCulture);
                    float temp = float.Parse(components[3], CultureInfo.InvariantCulture);
                    int index = (int)float.Parse(components[4], CultureInfo.InvariantCulture);
                    Point point = new Point(new Vector3(x, y, z), temp, index);
                    pointCloud.AddPunto(point);//Every line converted to a point is added to the point cloud

                }
                catch {
                    Console.WriteLine($"index is {i}");

                }
                
                
        //        Console.WriteLine($"indice {i}");
            }

            Console.WriteLine($"The point cloud has {pointCloud.size} points");
            Console.WriteLine($"The maximum in X is : {pointCloud.MaxX} and the minimum: {pointCloud.MinX}");
            Console.WriteLine($"The maximum in Y is: {pointCloud.MaxY} and the minimum: {pointCloud.MinY}");
            Console.WriteLine($"The maximum in Z is es: {pointCloud.MaxZ} and the minimum: {pointCloud.MinZ}");


            Console.WriteLine("Set the voxel width");
            float voxelSide = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            int voxelsAmountX = Convert.ToInt32(Math.Ceiling(pointCloud.LongX / voxelSide));
            int voxelsAmountY = Convert.ToInt32(Math.Ceiling(pointCloud.LongY / voxelSide));
            int voxelsAmountZ = Convert.ToInt32(Math.Ceiling(pointCloud.LongZ / voxelSide));
            Console.WriteLine($"The number of voxels in X is : {voxelsAmountX}");
            Console.WriteLine($"The number of voxels in Y is: {voxelsAmountY}");
            Console.WriteLine($"The number of voxels in Z is: {voxelsAmountZ}");

            Console.WriteLine($"Voxels total: {voxelsAmountX * voxelsAmountY * voxelsAmountZ}");//overflow issue!!!


            VoxelField voxelField = new VoxelField(pointCloud, voxelSide);

            float[] sizes = { pointCloud.LongX, pointCloud.LongY, pointCloud.LongZ };
            float initialWorldSize = sizes.Max(); //Greatest side among 3
            Octree.Point initialWorldPosition = new Octree.Point(pointCloud.MinX + (pointCloud.LongX / 2), pointCloud.MinY + (pointCloud.LongY / 2), pointCloud.MinZ + (pointCloud.LongZ / 2)); // Center
            PointOctree<Voxel> octree = new PointOctree<Voxel>(initialWorldSize, initialWorldPosition, 0.2f); //Octree's voxel creation

            //int indiceForEach = 0;
            foreach (Point point in pointCloud.Points)
            {
                //Voxel center to wich point lies
                float centroVoxelX = (float)Math.Floor((point.Location.X - pointCloud.MinX) / voxelField.LadoVoxel) * voxelField.LadoVoxel + voxelField.CentroVoxelInicialX;
                float centroVoxelY = (float)Math.Floor((point.Location.Y - pointCloud.MinY) / voxelField.LadoVoxel) * voxelField.LadoVoxel + voxelField.CentroVoxelInicialY;
                float centroVoxelZ = (float)Math.Floor((point.Location.Z - pointCloud.MinZ) / voxelField.LadoVoxel) * voxelField.LadoVoxel + voxelField.CentroVoxelInicialZ;
                Vector3 centroVoxelPunto = new Vector3(centroVoxelX, centroVoxelY, centroVoxelZ);

                Voxel[] voxelsTarget = octree.GetNearby(new Octree.Point(centroVoxelX, centroVoxelY, centroVoxelZ), voxelSide); //Potential voxel where the point lies are selected

                bool voxelExists = false;
                if (voxelsTarget.Length != 0)
                {
                    foreach (Voxel voxel in voxelsTarget)
                    {
                        if (voxel.Center == centroVoxelPunto)//If among the potential voxel, the voxel where the point lies is found, the point is added to such voxel
                        {
                            voxel.Points.Add(point);//add point to voxel
                            voxelExists = true;
                            break;
                        }
                    }
                }
                
                if (!voxelExists)//If the voxel does not exist, it is created
                {
                    Voxel newVoxel = new Voxel(centroVoxelPunto, voxelSide);
                    voxelField.voxeles.Add(newVoxel);
                    octree.Add(newVoxel, new Octree.Point(newVoxel.Center.X, newVoxel.Center.Y, newVoxel.Center.Z));
                    newVoxel.Points.Add(point);
                }
                //Console.WriteLine(indiceForEach++);
            }

            voxelField.GenerateCloud();
            Console.WriteLine("Process finished.");

            Console.ReadKey();

        }
    }
}
