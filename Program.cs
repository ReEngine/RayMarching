using System;


namespace RayMarching
{
    class Program
    {
        static int windowX = Console.LargestWindowWidth;
        static int windowY = Console.LargestWindowHeight;

        static void Main(string[] args)
        {


            if (args.Length != 0)
            {
                windowX = Convert.ToInt32(args[0]);
                windowY = Convert.ToInt32(args[1]);
            }


            Console.Title = "Console 3Dimensional Graphics Engine";
            Grid.InitializeScreen();
            Grid.InitializeGrid();



            //for (int i = 0; i < Grid.Width; i += 10)
            //    Grid.DrawLine(0, 0, i, Grid.Height - 1, ConsoleColor.Cyan);
            //for (int i = 0; i < Grid.Width; i += 10)
            //    Grid.DrawLine(Grid.Width - 1, 0, i, Grid.Height - 1, ConsoleColor.Magenta);
            //Grid.DrawCircle(Grid.Width-5, 20, 10, ConsoleColor.Red);
            //Rofl();
            //for (int i = 0; i < Grid.Width - 1;i++)
            //{
            //    for (int a = 0; a < Grid.Height - 1;a++)
            //    {
            //        Grid.DrawPoint(i, a, ConsoleColor.Blue);
            //    }
            //}
            //    Grid.FilCircle(10, 20, 5, ConsoleColor.Red);
            //Grid.FilCircle(Grid.Width / 2, 360, 310, ConsoleColor.Yellow);
            //Editor.EditorInitialize();
            //Vector3D vector1 = new Vector3D(1,2,3);
            //Console.WriteLine("Vector ("+ vector1.X + ", " + vector1.Y + ", " + vector1.Z + ").");
            //Console.WriteLine("Vector length = "+ vector1.Length());
            //vector1 = vector1.Normalize();
            //Console.WriteLine("Vector normalized = " + vector1.X + ", " + vector1.Y + ", " + vector1.Z);
            //Console.WriteLine("Normalized vector length = " + vector1.Length());
            //Console.ReadKey();
            //Console.Clear();

            for (double i = 0; ; i+= 0.1)
            {
                Render.RunTestScene(i);
            }


        }

    }
}
