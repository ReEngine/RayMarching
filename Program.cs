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



            Grid.InitializeScreen();
            Grid.InitializeGrid();
            

            //Grid.DrawPoint(4,4);
            Console.ReadKey();

        }
        
    }
}
