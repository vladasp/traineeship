using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGeom
{
    class Primitive
    {
        public delegate int DelegateType();
        public event DelegateType OnChangedLine;

        public int[] circle()
        {
            int[] CAr = new int [3];
            int R;
            do
            {
                Console.WriteLine("Enter R");
                R = OnChangedLine();
                //Check for the correct range
                if (R <= 0) { Console.WriteLine("Value is entered incorrectly"); }
            }
            while (R <= 0);

            Console.WriteLine("Enter x");
            int x = OnChangedLine();
            Console.WriteLine("Enter y");
            int y = OnChangedLine();
            CAr[0] = R;
            CAr[1] = x;
            CAr[2] = y;
           
            //Console.WriteLine("R : {0}; x : {1}; y : {2}", CAr[0], CAr[1], CAr[2]);
            return CAr;
        }

        public int[,] triangle()
        {
            int x1; int y1;int x2;int y2; int x3;int y3;
            bool FALSE = false;
            int[,] TAr = new int[3, 4];

            do
            {
                Console.WriteLine("Enter x1");
                x1 = OnChangedLine();
                Console.WriteLine("Enter y1");
                y1 = OnChangedLine();

                Console.WriteLine("Enter x2");
                x2 = OnChangedLine();
                Console.WriteLine("Enter y2");
                y2 = OnChangedLine();

                Console.WriteLine("Enter x3");
                x3 = OnChangedLine();
                Console.WriteLine("Enter y3");
                y3 = OnChangedLine();

                //Check for origin (identical points and one line)
                if (x1 != x2 && y1 != y2) { FALSE = true; }
                else if (x1 != x3 && y1 != y3) { FALSE = true; }
                else if (x2 != x3 && y2 != y3) { FALSE = true; }
                else
                {
                    Console.WriteLine("Value is entered incorrectly");
                }
            }
            while (FALSE == false);

            TAr[0, 0] = x1; TAr[0, 1] = y1; TAr[0, 2] = x2; TAr[0, 3] = y2;
            TAr[1, 0] = x2; TAr[1, 1] = y2; TAr[1, 2] = x3; TAr[1, 3] = y3;
            TAr[2, 0] = x3; TAr[2, 1] = y3; TAr[2, 2] = x1; TAr[2, 3] = y1;

            //Console.WriteLine("x1: {0}; y1: {1}; x2: {2}, y2: {3}, x3: {4}, y3: {5}", TAr[0, 0], TAr[0, 1], TAr[0, 2], TAr[0, 3], TAr[1, 2], TAr[1, 3]);

            return TAr;
        }

        public int [,] square()
        {
            int x1; int y1; int x2; int y2;
            bool FALSE = false;
            int[,] SAr = new int[4,4];

            do
            {
                Console.WriteLine("Enter x1");
                x1 = OnChangedLine();
                Console.WriteLine("Enter y1");
                y1 = OnChangedLine();

                Console.WriteLine("Enter x2");
                x2 = OnChangedLine();
                Console.WriteLine("Enter y2");
                y2 = OnChangedLine();

                //Check for origin (identical points)
                if (x1 != x2 && y1 != y2) { FALSE = true; }
                else
                {
                    Console.WriteLine("Value is entered incorrectly");
                }
            }
            while (FALSE == false);

            SAr[0, 0] = x1; SAr[0, 1] = y1; SAr[0, 2] = x1; SAr[0, 3] = y2;
            SAr[1, 0] = x1; SAr[1, 1] = y2; SAr[1, 2] = x2; SAr[1, 3] = y2;
            SAr[2, 0] = x2; SAr[2, 1] = y2; SAr[2, 2] = x2; SAr[2, 3] = y1;
            SAr[3, 0] = x2; SAr[3, 1] = y1; SAr[3, 2] = x1; SAr[3, 3] = y1;
            
            return SAr;
        }
    }
}

   