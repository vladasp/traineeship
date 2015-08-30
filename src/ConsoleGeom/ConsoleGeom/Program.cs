using System;
using System.Collections.Generic;

namespace ConsoleGeom
{
    class Program
    {
        enum Figure { triangle = 1, square = 2, circle = 3 }

        static void Main(string[] args)
        {
            Instuctions();
            Primitive primitive = new Primitive();
            ClassEvent classEvent = new ClassEvent();
            primitive.OnChangedLine += classEvent.ChangedLine;
            bool isExit = false;
            string input;
            bool primitiveChacked;
            int triangle;
            int square;
            int circle;
            int firstPrimitive = 0;
            int secondPrimitive = 0;

            while (!isExit)
                {
                input = Console.ReadLine();
                    switch (input)
                    {
                        case "R":
                            {
                                double[] firstCircle = new double[3]; double[] secondCircle = new double[3];
                                double[,] firstTriangle = new double[3, 4]; double[,] secondTriangle = new double[3, 4];
                                double[,] firstSquare = new double[4, 4]; double[,] secondSquare = new double[4, 4];
                                triangle = (int)Figure.triangle;
                                square = (int)Figure.square;
                                circle = (int)Figure.circle;


                                /// primitiveArray have all choices of the primitive:
                                /// 1 - triangle
                                /// 2 - square
                                /// 3 - circle

                                #region  First primitive
                                do
                                {
                                    Console.WriteLine("Select first primitive (1 - triangle, 2 -square, 3 - circle)");
                                    primitiveChacked = false;
                                    string number = Console.ReadLine();

                                    if (int.Parse(number) == triangle)
                                    {
                                        firstTriangle = primitive.TrianglePrimitive();
                                        primitiveChacked = true;
                                        firstPrimitive = 1;
                                    }
                                    else if (int.Parse(number) == square)
                                    {
                                        firstSquare = primitive.SquarePrimitive();
                                        primitiveChacked = true;
                                        firstPrimitive = 2;
                                    }
                                    else if (int.Parse(number) == circle)
                                    {
                                        firstCircle = primitive.CirclePrimitive();
                                        primitiveChacked = true;
                                        firstPrimitive = 3;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Value is entered incorrectly");
                                    }
                                }
                                while (!primitiveChacked);
                                #endregion

                                #region Second primitive
                                do
                                {
                                    Console.WriteLine("Select second primitive (1 - triangle, 2 -square, 3 - circle)");
                                    primitiveChacked = false;
                                    string number = Console.ReadLine();
                                    if (int.Parse(number) == triangle)
                                    {
                                        secondTriangle = primitive.TrianglePrimitive();
                                        primitiveChacked = true;
                                        secondPrimitive = 1;
                                    }
                                    else if (int.Parse(number) == square)
                                    {
                                        secondSquare = primitive.SquarePrimitive();
                                        primitiveChacked = true;
                                        secondPrimitive = 2;
                                    }
                                    else if (int.Parse(number) == circle)
                                    {
                                        secondCircle = primitive.CirclePrimitive();
                                        primitiveChacked = true;
                                        secondPrimitive = 3;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Value is entered incorrectly");
                                    }
                                }
                                while (!primitiveChacked);
                                #endregion

                                #region  Intersections primitives
                                // Intersections Circle And Line
                                if (firstPrimitive == circle && secondPrimitive == triangle)
                                {
                                    IntersectionsCircleAndLine(firstCircle, secondTriangle);
                                }
                                else if (firstPrimitive == triangle && secondPrimitive == circle)
                                {
                                    IntersectionsCircleAndLine(secondCircle, firstTriangle);
                                }
                                else if (firstPrimitive == circle && secondPrimitive == square)
                                {
                                    IntersectionsCircleAndLine(firstCircle, secondSquare);
                                }
                                else if (firstPrimitive == square && secondPrimitive == circle)
                                {
                                    IntersectionsCircleAndLine(secondCircle, firstSquare);
                                }
                                // Intersections Circle And Circle
                                else if (firstPrimitive == circle && secondPrimitive == circle)
                                {
                                    IntersectionsCircleAndCircle(firstCircle, secondCircle);
                                }
                                // Intersections Circle And Circle
                                else if (firstPrimitive == square && secondPrimitive == square)
                                {
                                    IntersectionsLineAndLine(firstSquare, secondSquare);
                                }
                                else if (firstPrimitive == triangle && secondPrimitive == triangle)
                                {
                                    IntersectionsLineAndLine(firstTriangle, secondTriangle);
                                }
                                else if (firstPrimitive == square && secondPrimitive == triangle)
                                {
                                    IntersectionsLineAndLine(firstSquare, secondTriangle);
                                }
                                else if (firstPrimitive == triangle && secondPrimitive == square)
                                {
                                    IntersectionsLineAndLine(secondSquare, firstTriangle);
                                }
                            #endregion

                            break;
                            }
                            case "E":
                                {
                        isExit = true; break;
                    }
                    default: Instuctions(); break;
                }
            }
}       

        static public List<double> IntersectionsCircleAndLine(double[] parametersCircle, double[,] parametersLine)
        {
            double k = 0; double l = 0;
            double a; double b; double c;
            List<double> intersectionsArray = new List<double>();
            double x1 = 0; double x2 = 0; double y1 = 0; double y2 = 0; double discriminant = 0;

            for (int i = 0; i < (parametersLine.Length / 4); i++)
            {
                double x11 = parametersLine[i, 0]; double y11 = parametersLine[i, 1]; double y12 = parametersLine[i, 2]; double y22 = parametersLine[i, 3];
                double deltaX = y12 - x11; double deltaY = y22 - y11;

                if (deltaX != 0 && deltaY != 0)
                {
                    k = deltaX / deltaY; l = y11 - (x11 * deltaY / deltaX);
                }
                else if (deltaY != 0 && deltaX == 0)
                {
                    k = 0; l = x11;
                }
                else if (deltaX != 0 && deltaY == 0)
                {
                    k = 0; l = y11;
                }

                double centerX = parametersCircle[1]; double centerY = parametersCircle[2]; double radius = parametersCircle[0];
                a = 1 + k * k;
                b = 2 * (k * l - centerX - centerY * k);
                c = l * l - 2 * centerX * l + centerY * centerY + centerX * centerX - radius * radius;

                discriminant = GetQuadraticEquation(a, b, c)[0];
                if (discriminant > 0)
                {
                    if (deltaX == 0)
                    {
                        y1 = GetQuadraticEquation(a, b, c)[1]; x1 = k * y1 + l;
                        y2 = GetQuadraticEquation(a, b, c)[2]; x2 = k * y2 + l;
                    }
                    else
                    {
                        x1 = GetQuadraticEquation(a, b, c)[1]; y1 = k * x1 + l;
                        x2 = GetQuadraticEquation(a, b, c)[2]; y2 = k * x2 + l;
                    }
                }
                if (discriminant == 0)
                {
                    if (deltaX == 0)
                    {
                        y1 = GetQuadraticEquation(a, b, c)[1]; x1 = k * y1 + l;
                    }
                    else
                    {
                        x1 = GetQuadraticEquation(a, b, c)[1]; y1 = k * x1 + l;
                    }
                }
                if ((y1 > y11 && y1 < y22 || y1 < y11 && y1 > y22 || y1 == y11 || y1 == y22)
                && (x1 > x11 && x1 < y12 || x1 < x11 && x1 > y12 || x1 == x11 || x1 == y12))
                {
                    intersectionsArray.Add(x1);
                    intersectionsArray.Add(y1);
                    Console.WriteLine("X: {0}, Y: {1}", x1, y1);
                }

                if ((y2 > y11 && y2 < y22 || y2 < y11 && y2 > y22 || y2 == y11 || y2 == y22)
                    && (x2 > x11 && x2 < y12 || x2 < x11 && x2 > y12 || x2 == x11 || x2 == y12))
                {
                    intersectionsArray.Add(x2);
                    intersectionsArray.Add(y2);
                    Console.WriteLine("X: {0}, Y: {1}", x2, y2);
                }
            }

            if (intersectionsArray.Count == 0)
            {
                Console.WriteLine("No intersections primitives");
            }

            return intersectionsArray;
        }

        static public List<double> IntersectionsCircleAndCircle(double[] parametersFirstCircle, double[] parametersSecondCircle)
        {
            double xCenterZero; double yCenterZero; double e;
            double a; double b; double c;
            List<double> intersectionsArray = new List<double>();

            xCenterZero = parametersSecondCircle[1] - parametersFirstCircle[1];
            yCenterZero = parametersSecondCircle[2] - parametersFirstCircle[2];
            e = (parametersSecondCircle[0] * parametersSecondCircle[0] - xCenterZero * xCenterZero - yCenterZero * yCenterZero - parametersFirstCircle[0] * parametersFirstCircle[0]) / (-2);

            a = xCenterZero * xCenterZero + yCenterZero * yCenterZero;
            b = -2 * yCenterZero * e;
            c = e * e - xCenterZero * xCenterZero * parametersFirstCircle[0] * parametersFirstCircle[0];

            double discriminant = GetQuadraticEquation(a, b, c)[0];
            double x1 = GetQuadraticEquation(a, b, c)[1];
            double x2 = GetQuadraticEquation(a, b, c)[2];

            if (discriminant > 0)
            {
                intersectionsArray.Add((e - x1 * yCenterZero) / xCenterZero);
                intersectionsArray.Add(x1);
                intersectionsArray.Add((e - x2 * yCenterZero) / xCenterZero);
                intersectionsArray.Add(x2);
                Console.WriteLine("X1: {0}, Y1: {1}, X2: {2}, Y2: {3}", intersectionsArray[0], intersectionsArray[1], intersectionsArray[2], intersectionsArray[3]);
            }
            if (discriminant == 0)
            {
                intersectionsArray.Add(x1);
                intersectionsArray.Add((e - x1 * yCenterZero) / xCenterZero);
                Console.WriteLine("X: {0}, Y: {1}", intersectionsArray[0], intersectionsArray[1]);
            }
            if (intersectionsArray.Count == 0)
            {
                Console.WriteLine("No intersections primitives");
            }

            return intersectionsArray;
        }

        static public List<double> IntersectionsLineAndLine(double[,] parametersFirstLine, double[,] parametersSecondLine)
        {
            double k1; double l1; double k2; double l2;
            double x = 0; double y = 0;

            List<double> intersectionsArray = new List<double>();

            for (int i = 0; i < (parametersFirstLine.Length / 4); i++)
            {
                for (int j = 0; j < (parametersSecondLine.Length / 4); j++)
                {
                    double x11 = parametersFirstLine[i, 0]; double y11 = parametersFirstLine[i, 1]; double x12 = parametersFirstLine[i, 2]; double y12 = parametersFirstLine[i, 3];
                    double x21 = parametersSecondLine[j, 0]; double y21 = parametersSecondLine[j, 1]; double x22 = parametersSecondLine[j, 2]; double y22 = parametersSecondLine[j, 3];
                    double deltaX1 = x12 - x11; double deltaY1 = y12 - y11;
                    double deltaX2 = x22 - x21; double deltaY2 = y22 - y21;

                    // Without dY = 0 dX = 0
                    if (deltaX1 != 0 && deltaX2 != 0 && deltaY1 != 0 && deltaY2 != 0)
                    {
                        k1 = deltaY1 / deltaX1;
                        l1 = y11 - (x11 * deltaY1 / deltaX1);
                        k2 = deltaY2 / deltaX2;
                        l2 = y21 - (x21 * deltaY2 / deltaX2);
                        x = (k1 - (k2 / l2)) / (1 - (l1 / l2));
                        y = k1 * x + l1;
                    }

                    // Without dY = 0
                    if (deltaX1 != 0 && deltaX2 != 0 && deltaY1 == 0 && deltaY2 != 0)
                    {
                        k1 = 0;
                        l1 = y11;
                        k2 = deltaY2 / deltaX2;
                        l2 = y21 - (x21 * deltaY2 / deltaX2);
                        x = (k1 - (k2 / l2)) / (1 - (l1 / l2));
                        y = k1 * x + l1;
                    }
                    if (deltaX1 != 0 && deltaX2 != 0 && deltaY1 != 0 && deltaY2 == 0)
                    {
                        k1 = deltaY1 / deltaX1;
                        l1 = y11 - (x11 * deltaY1 / deltaX1);
                        k2 = 0;
                        l2 = y21;
                        x = (k1 - (k2 / l2)) / (1 - (l1 / l2));
                        y = k1 * x + l1;
                    }
                    // Without dX = 0
                    if (deltaX1 == 0 && deltaX2 != 0 && deltaY1 != 0 && deltaY2 != 0)
                    {
                        k1 = 0;
                        l1 = x11;
                        k2 = deltaX2 / deltaY2;
                        l2 = x21 - (y21 * deltaX2 / deltaY2);
                        y = (k1 - (k2 / l2)) / (1 - (l1 / l2));
                        x = k1 * y + l1;
                    }
                    if (deltaX1 != 0 && deltaX2 == 0 && deltaY1 != 0 && deltaY2 != 0)
                    {
                        k1 = deltaX1 / deltaY1;
                        l1 = x11 - (y11 * deltaX1 / deltaY1);
                        k2 = 0;
                        l2 = x21;
                        y = (k1 - (k2 / l2)) / (1 - (l1 / l2));
                        x = k1 * y + l1;
                    }
                    // With Y = 0 X = 0;
                    if (deltaX2 == 0 && deltaY1 == 0)
                    {
                        x = x21;
                        y = y11;
                    }
                    if (deltaX1 == 0 && deltaY2 == 0)
                    {
                        x = x11;
                        y = y21;
                    }
                    if ((y > y11 && y < y12 || y < y11 && y > y12 || y == y11 || y == y12)
                        && (y > y21 && y < y22 || y < y21 && y > y22 || y == y21 || y == y22)
                        && (x > x11 && x < x12 || x < x11 && x > x12 || x == x11 || x == x12)
                        && (x > x21 && x < x22 || x < x21 && x > x22 || x == x21 || x == x22)
                        && (x > x21 && x < x22 || x < x21 && x > x22 || x == x21 || x == x22))
                    {
                        intersectionsArray.Add(x);
                        intersectionsArray.Add(y);
                        Console.WriteLine("X1: {0}, Y1: {1}", x, y);
                    }
                }
            }

            if (intersectionsArray.Count == 0)
            {
                Console.WriteLine("No intersections primitives");
            }
            return intersectionsArray;
        }

        static public double[] GetQuadraticEquation(double a, double b, double c)
        {
            double discriminant;
            double x1 = 0;
            double x2 = 0;
            double[] resultArray = new double[3];

            discriminant = b * b - 4 * a * c;

            if (discriminant >= 0)
            {
                x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            }
            resultArray[0] = discriminant;
            resultArray[1] = x1;
            resultArray[2] = x2;
            return resultArray;
        }

        static void Instuctions()
        {
            Console.Clear();
            Console.WriteLine("To run the program enter 'R', to exit enter 'E'");
        }

    }
}



