using System;
using System.Collections.Generic;
using System.Text;

namespace RayMarching
{
    class Editor
    {
        static public void Construct()
        {

        }
        static public void EditorInitialize()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            DrawInterface();
        }
        static void DrawInterface()
        {
            Grid.DrawRectangle(1, 1, 15, 30, ConsoleColor.White);
            Grid.FillRectangle(2, 2, 14, 29, ConsoleColor.DarkBlue);
            Console.SetCursorPosition(4, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("Editor");

            DrawCircle();


        }
        static void DrawCircle()
        {
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                MarkPoint(Grid.Width / 2, Grid.Height / 2);
            }
        }
        static void MarkPoint(int x, int y)
        {
            try
            {
                if (y < Grid.Height - 1)
                {
                    Console.SetCursorPosition(x * 2, y);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("▒▒");
                }
            }
            catch
            {

            }


            // Console.Write("##");
        }


    }
}
