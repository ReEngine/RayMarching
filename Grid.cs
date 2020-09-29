using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace RayMarching
{
    class Grid
    {
        static int windowX = Console.LargestWindowWidth;
        static int windowY = Console.LargestWindowHeight;

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);



        static public int Width;
        static public int Height;

        static public void InitializeGrid()
        {
            Width = Console.WindowWidth / 2;
            Height = Console.WindowHeight;
        }
        static public void InitializeScreen()
        {

            if (windowX % 2 != 0)
            {
                windowX--;
            }
            Console.CursorVisible = false;
            Console.SetWindowSize(windowX, windowY);
            ShowWindow(ThisConsole, 3);
            Console.CursorVisible = false;

        }

        static bool Swap<T>(ref T x, ref T y)
        {
            try
            {
                T t = y;
                y = x;
                x = t;
                return true;
            }
            catch
            {
                return false;
            }
        }
        static public void DrawPoint(int x, int y)
        {
            DrawPoint(x, y, ConsoleColor.Gray);
        }
        static public void DrawPoint(int x, int y, ConsoleColor color)
        {
            try
            {
                if (y < Grid.Height - 1)
                {
                    Console.SetCursorPosition(x * 2, y);
                    Console.ForegroundColor = color;
                    Console.Write("██");
                }
            }
            catch
            {

            }


            // Console.Write("##");
        }
        static public void DrawPoint(int x, int y, char symbol)
        {
            try
            {
                if (y < Grid.Height - 1)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(x * 2, y);
                    Console.Write(symbol);
                    Console.Write(symbol);
                }
            }
            catch
            {

            }


            // Console.Write("##");
        }
        static public void DrawLine(int x0, int y0, int x1, int y1)
        {
            DrawLine(x0, y0, x1, y1, ConsoleColor.Gray);
        }
        static public void DrawLine(int x0, int y0, int x1, int y1, ConsoleColor color)
        {
            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            if (steep)
            {
                Swap<int>(ref x0, ref y0);
                Swap<int>(ref x1, ref y1);
            }

            if (x0 > x1)
            {
                Swap<int>(ref x0, ref x1);
                Swap<int>(ref y0, ref y1);
            }

            int dx, dy;
            dx = x1 - x0;
            dy = Math.Abs(y1 - y0);

            int err = dx / 2;
            int ystep;

            if (y0 < y1)
            {
                ystep = 1;
            }
            else
            {
                ystep = -1;
            }

            for (; x0 <= x1; x0++)
            {
                if (steep)
                {
                    DrawPoint(y0, x0, color);
                }
                else
                {
                    DrawPoint(x0, y0, color);
                }
                err -= dy;
                if (err < 0)
                {
                    y0 += ystep;
                    err += dx;
                }
            }
        }
        static public void DrawCircle(int x0, int y0, int r)
        {
            DrawCircle(x0, y0, r, ConsoleColor.Red);
        }
        static public void DrawCircle(int x0, int y0, int r, ConsoleColor color)
        {
            int f = 1 - r;
            int ddF_x = 1;
            int ddF_y = -2 * r;
            int x = 0;
            int y = r;


            DrawPoint(x0, y0 + r, color);
            DrawPoint(x0, y0 - r, color);
            DrawPoint(x0 + r, y0, color);
            DrawPoint(x0 - r, y0, color);

            while (x < y)
            {
                if (f >= 0)
                {
                    y--;
                    ddF_y += 2;
                    f += ddF_y;
                }
                x++;
                ddF_x += 2;
                f += ddF_x;

                DrawPoint(x0 + x, y0 + y, color);
                DrawPoint(x0 - x, y0 + y, color);
                DrawPoint(x0 + x, y0 - y, color);
                DrawPoint(x0 - x, y0 - y, color);
                DrawPoint(x0 + y, y0 + x, color);
                DrawPoint(x0 - y, y0 + x, color);
                DrawPoint(x0 + y, y0 - x, color);
                DrawPoint(x0 - y, y0 - x, color);
            }

        }
        static public void FilCircle(int x0, int y0, int r, ConsoleColor color)
        {
            for (int i = r; i > 0; i--)
            {
                DrawCircle(x0, y0, i, color);
            }
        }
        static public void FilCircle(int x0, int y0, int r)
        {
            FilCircle(x0, y0, r, ConsoleColor.Gray);
        }
        static public void DrawRectangle(int x0, int y0, int x1, int y1, ConsoleColor color)
        {
            Grid.DrawLine(x0, y0, x0, y1, color);
            Grid.DrawLine(x0, y0, x1, y0, color);
            Grid.DrawLine(x1, y0, x1, y1, color);
            Grid.DrawLine(x0, y1, x1, y1, color);

        }
        static public void DrawRectangle(int x0, int y0, int x1, int y1)
        {
            DrawRectangle(x0, y0, x1, y1, ConsoleColor.Gray);
        }
        static public void FillRectangle(int x0, int y0, int x1, int y1, ConsoleColor color)
        {
            for (int i = x0; i <= x1; i++)
            {
                Grid.DrawLine(i, y0, i, y1,color);
            }
        }
    }
}

