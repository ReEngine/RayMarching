using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RayMarching
{
    class Render
    {
        static int maxSteps = 100;
        static double minDistance = 0.01;
        static double maxDistance = 100;




        public static void RunTestScene()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Vector3D rayDirection;
            Vector3D camera = new Vector3D(0, 1, 0);
            int pX = 0;
            int pY = 0;
            for (int y = -Grid.Height / 2; y < Grid.Height / 2; y++)
            {
                for (int x = -Grid.Width / 2; x < Grid.Width / 2; x++)
                {
                    Vector3D pixelDrawing = new Vector3D(x, y, 100);
                    rayDirection = Vector3D.Subtract(pixelDrawing, camera).Normalize();
                    double d = RayMarch(camera, rayDirection);
                    d /= 6;
                    if (d < 8)
                        Grid.DrawPoint(pX, pY, ' ');
                    if ((d >= 8) & (d < 16))
                        Grid.DrawPoint(pX, pY, '▒');
                    if ((d >= 16) & (d < 24))
                        Grid.DrawPoint(pX, pY, '▒');
                    if ((d >= 24) & (d < 32))
                        Grid.DrawPoint(pX, pY, '▓');
                    if (d >= 32)
                        Grid.DrawPoint(pX, pY, '█');
                    pX++;

                    //

                }
                pX = 0;
                pY++;
            }
            //Console.WriteLine("\n\n\nmin_d: " + min_d);
            //Console.WriteLine("max_d: " + max_d);

        }
        public static double RayMarch(Vector3D camera, Vector3D rayDirection)
        {
            double distanceFromStart = 0;
            for (int i = 0; i < maxSteps; i++)
            {
                Vector3D point = Vector3D.Add(camera, Vector3D.Multiply(rayDirection, distanceFromStart));
                double distanceToScene = GetClosestDistance(point);
                distanceFromStart += distanceToScene;
                if ((distanceFromStart > maxDistance) || (distanceToScene < minDistance))
                    break;
            }
            return distanceFromStart;
        }
        public static double GetClosestDistance(Vector3D point)
        {
            Sphere4D sphere = new Sphere4D(2, 1, 10, 1);

            double distanceToSphere = Vector3D.Length(Vector3D.Subtract(point, sphere.Position())) - sphere.Radius;
            double distancetoPlain = point.Y;
            double closestDistance = Math.Min(distancetoPlain, distanceToSphere);
            return closestDistance;
        }
    }
    public struct Sphere4D
    {
        public Sphere4D(double x, double y, double z, double radius)
        {
            X = x;
            Y = y;
            Z = z;
            Radius = radius;

        }
        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public double Radius { get; }

        public Vector3D Position()
        {
            Vector3D position = new Vector3D(X, Y, Z);
            return position;
        }

    }

}
