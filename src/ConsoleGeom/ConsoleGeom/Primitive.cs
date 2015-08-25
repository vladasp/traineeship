using System;

namespace ConsoleGeom
{
    class Primitive
    {
        public delegate double DelegateType();
        public event DelegateType OnChangedLine;

        public double[] CirclePrimitive()
        {
            double[] circleArray = new double[3];
            double radiusCircle;
            do
            {
                Console.WriteLine("Enter R");
                radiusCircle = OnChangedLine();
                //Check for the correct range
                if (radiusCircle <= 0) { Console.WriteLine("Value is entered incorrectly"); }
            }
            while (radiusCircle <= 0);

            Console.WriteLine("Enter x");
            double x = OnChangedLine();
            Console.WriteLine("Enter y");
            double y = OnChangedLine();
            circleArray[0] = radiusCircle;
            circleArray[1] = x;
            circleArray[2] = y;

            return circleArray;
        }

        public double[,] TrianglePrimitive()
        {
            double x1; double y1; double x2; double y2; double x3; double y3;
            bool checkPoints = false;
            double[,] triangleArray = new double[3, 4];

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
                if (x1 != x2 && y1 != y2) { checkPoints = true; }
                else if (x1 != x3 && y1 != y3) { checkPoints = true; }
                else if (x2 != x3 && y2 != y3) { checkPoints = true; }
                else
                {
                    Console.WriteLine("Value is entered incorrectly");
                }
            }
            while (!checkPoints);

            triangleArray[0, 0] = x1; triangleArray[0, 1] = y1; triangleArray[0, 2] = x2; triangleArray[0, 3] = y2;
            triangleArray[1, 0] = x2; triangleArray[1, 1] = y2; triangleArray[1, 2] = x3; triangleArray[1, 3] = y3;
            triangleArray[2, 0] = x3; triangleArray[2, 1] = y3; triangleArray[2, 2] = x1; triangleArray[2, 3] = y1;

            return triangleArray;
        }

        public double[,] SquarePrimitive()
        {
            double x1; double y1; double x2; double y2;
            bool checkPoints = false;
            double[,] squareArray = new double[4, 4];

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
                if (x1 != x2 && y1 != y2) { checkPoints = true; }
                else
                {
                    Console.WriteLine("Value is entered incorrectly");
                }
            }
            while (!checkPoints);

            squareArray[0, 0] = x1; squareArray[0, 1] = y1; squareArray[0, 2] = x1; squareArray[0, 3] = y2;
            squareArray[1, 0] = x1; squareArray[1, 1] = y2; squareArray[1, 2] = x2; squareArray[1, 3] = y2;
            squareArray[2, 0] = x2; squareArray[2, 1] = y2; squareArray[2, 2] = x2; squareArray[2, 3] = y1;
            squareArray[3, 0] = x2; squareArray[3, 1] = y1; squareArray[3, 2] = x1; squareArray[3, 3] = y1;

            return squareArray;
        }
    }
}

