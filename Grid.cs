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
            Console.SetCursorPosition(x * 2, y);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("██");
        }
        static public void DrawLine(int x0, int y0, int x1, int y1)
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
                    DrawPoint(y0, x0);
                }
                else
                {
                    DrawPoint(x0, y0);
                }
                err -= dy;
                if (err < 0)
                {
                    y0 += ystep;
                    err += dx;
                }
            }
        }
    }
}
