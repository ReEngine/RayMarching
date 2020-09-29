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

        static int pX = 0;
        static int pY = 0;

        static double counter = 0;

        public static void RunTestScene(double iterations)
        {
            counter = iterations;
            Console.BackgroundColor = ConsoleColor.White;
            //Console.Clear();
            Vector3D rayDirection;
            Vector3D camera = new Vector3D(0, 1, 1);
            pX = 0;
            pY = 0;
            for (int y = Grid.Height / 2; y > -Grid.Height / 2; y--)
            {
                for (int x = Grid.Width / 2; x > -Grid.Width / 2; x--)
                {
                    Vector3D pixelDrawing = new Vector3D(x, y, 80);
                    rayDirection = Vector3D.Subtract(pixelDrawing, camera).Normalize();
                    double d = RayMarch(camera, rayDirection);

                    Vector3D point = Vector3D.Add(camera, Vector3D.Multiply(rayDirection, d));
                    double LightDiffuse = GetLight(point);

                    LightDiffuse *=7;
                    if (LightDiffuse < 1)
                        Grid.DrawPoint(pX, pY, '█');
                    if ((LightDiffuse >= 1) & (LightDiffuse < 2))
                        Grid.DrawPoint(pX, pY, '▓');
                    if ((LightDiffuse >= 2) & (LightDiffuse < 3))
                        Grid.DrawPoint(pX, pY, '▒');
                    if ((LightDiffuse >= 3) & (LightDiffuse < 4))
                        Grid.DrawPoint(pX, pY, '▒');
                    if (LightDiffuse >= 4)
                        Grid.DrawPoint(pX, pY, ' ');
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
        public static Vector3D GetNormal(Vector3D point)
        {
            double d = GetClosestDistance(point);
            Vector3D Normal = Vector3D.Subtract(new Vector3D(d, d, d), new Vector3D(
                GetClosestDistance(Vector3D.Subtract(point, new Vector3D(0.01, 0, 0))),
                GetClosestDistance(Vector3D.Subtract(point, new Vector3D(0, 0.01, 0))),
                GetClosestDistance(Vector3D.Subtract(point, new Vector3D(0, 0, 0.01)))));
            return Vector3D.Normalize(Normal);

        }
        public static double GetLight(Vector3D point)
        {
            double posX = 0;
            double posZ = 6;
            posX += Math.Sin(counter)*5;
            posZ += Math.Cos(counter)*5;
            Vector3D lightPosition = new Vector3D(10+posX, 10, -10 + posZ);
            
            Vector3D lightVector = Vector3D.Normalize(Vector3D.Subtract(lightPosition, point));
            Vector3D normal = GetNormal(point);

            double difuse = Vector3D.DotProduct(normal, lightVector);
            double d = RayMarch(Vector3D.Add(point, Vector3D.Multiply(normal, minDistance * 10)), lightVector);
            if (d < Vector3D.Length(Vector3D.Subtract(lightPosition, point)))
                difuse *= 0.5*Math.Sin(counter);
            return difuse;
        }
        public static double GetClosestDistance(Vector3D point)
        {
            double spherePosY = Math.Sin(counter)*1;
            
            Sphere4D sphere = new Sphere4D(2, 2+spherePosY, 10, 1);

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
