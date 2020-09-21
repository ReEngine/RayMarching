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



            for (int i = 0; i < Grid.Width; i += 10)
                Grid.DrawLine(0, 0, i, Grid.Height - 1, ConsoleColor.Cyan);
            for (int i = 0; i < Grid.Width; i += 10)
                Grid.DrawLine(Grid.Width - 1, 0, i, Grid.Height - 1, ConsoleColor.Magenta);
            Grid.DrawCircle(Grid.Width-5, 20, 10, ConsoleColor.Red);
            
            Console.ReadKey();
            

        }
        static void Rofl()
        {
            string message = "Помогите!";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, Console.WindowHeight / 2);
            Console.Write(message);
            message = "Я заебался!";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, Console.WindowHeight / 2 + 1);
            Console.Write(message);
            message = "Я пишу этиу хуйню уже несколько часов...";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, Console.WindowHeight / 2 + 2);
            Console.Write(message);
            message = "Но так и не добился почти ничего из того, что задумывал до этого.";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, Console.WindowHeight / 2 + 3);
            Console.Write(message);
            message = "Это всё равно, что рисовать на печатной машинке!";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, Console.WindowHeight / 2 + 4);
            Console.Write(message);
            message = "Тут могла быть ваша реклама!";
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, Console.WindowHeight / 2 + 5);
            Console.Write(message);
            message = "ХИМТЕХ ЛУЧШЕ ВСЕХ!";
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, Console.WindowHeight / 2 + 6);
            Console.Write(message);
        }

    }
}
