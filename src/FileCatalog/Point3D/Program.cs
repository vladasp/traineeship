using System;
using System.Collections.Generic;

namespace Point3D
{
    enum UserControl { Add = 1, M, C, D, Show, E}

    class Program
    {
        static void Main(string[] args)
        {
            List<Point> pointsList = new List<Point>();
            Point point = new Point();
            bool isExit = false;
            string input;
            int countPoints;
            int indexPoint;
            const string addControl = "A";
            const string mooveControl = "M";
            const string stringControl = "S";
            const string distanceControl = "D";
            const string showControl = "Show";
            const string exitControl = "E";

            Console.WriteLine("Enter count of points from 1 to 5");
            countPoints = ChangedLineInt();

            if (countPoints < 6 && countPoints > 0)
            {
                for (int i = 0; countPoints > i ; i++)
                {
                    Console.WriteLine("Enter coordinates of {0} point", i + 1);
                    pointsList.Add(new Point());
                    pointsList[i].AddPoint();
                    Console.WriteLine("point {0} x = {1} y = {2} z = {3} ", i+1, pointsList[i].x, pointsList[i].y, pointsList[i].z);
                }
            }
            while (!isExit)
            {
                input = Console.ReadLine();

                switch (input)
                {
                    #region MooveTo
                    case mooveControl:
                        {
                            Console.WriteLine("Enter the point you what to moove");
                            do
                            {
                                indexPoint = ChangedLineInt();
                                if (indexPoint > pointsList.Count || indexPoint < 1)
                                {
                                    Console.WriteLine("Index point out of range");
                                }
                                else
                                {
                                    pointsList[indexPoint-1].MooveTo();
                                }
                            }
                            while (indexPoint > pointsList.Count || indexPoint < 1);
                            break;
                        }
                    #endregion
                    #region Create to string
                    case stringControl:
                        {
                            Console.WriteLine("Enter the point you what to see");
                            do
                            {
                                indexPoint = ChangedLineInt();
                                if (indexPoint > pointsList.Count || indexPoint < 1)
                                {
                                    Console.WriteLine("Index point out of range");
                                }
                            }
                            while (indexPoint > pointsList.Count || indexPoint < 1);
                            pointsList[indexPoint-1].PointToString();
                            break;
                        }
                    #endregion
                    #region Distance
                    case distanceControl:
                        {
                            int firstIndexPoint, secondindexPoint;
                            do
                            {
                                Console.WriteLine("Enter firsr point");
                                firstIndexPoint = ChangedLineInt();
                                if (firstIndexPoint > pointsList.Count || firstIndexPoint < 1)
                                {
                                    Console.WriteLine("Index point out of range");
                                }
                            }
                            while (firstIndexPoint > pointsList.Count || firstIndexPoint < 1);
                            do
                            {
                                Console.WriteLine("Enter second point");
                                secondindexPoint = ChangedLineInt();
                                if (secondindexPoint > pointsList.Count || secondindexPoint < 1)
                                {
                                    Console.WriteLine("Index point out of range");
                                }
                            }
                            while (secondindexPoint > pointsList.Count && secondindexPoint!= firstIndexPoint || secondindexPoint < 1 && secondindexPoint != firstIndexPoint);
                            double x1 = pointsList[firstIndexPoint - 1].x;
                            double y1 = pointsList[firstIndexPoint - 1].y;
                            double z1 = pointsList[firstIndexPoint - 1].z;
                            double x2 = pointsList[secondindexPoint - 1].x;
                            double y2 = pointsList[secondindexPoint - 1].y;
                            double z2 = pointsList[secondindexPoint - 1].z;
                            double distance = Math.Round(Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2) + Math.Pow((z1 - z2), 2)), 2);
                            Console.WriteLine("Distanse distance between the points {0}", distance);
                            break;
                        }
                    #endregion
                    #region Add new point
                    case addControl:
                    {
                            pointsList.Add(new Point());
                            Console.WriteLine("Enter coordinates of {0} point", pointsList.Count);
                            pointsList[pointsList.Count-1].AddPoint();
                            Console.WriteLine("Point {0} x = {1} y = {2} z = {3} ", pointsList.Count, pointsList[pointsList.Count-1].x, pointsList[pointsList.Count-1].y, pointsList[pointsList.Count-1].z);
                            break;
                    }
                    #endregion
                    #region Show all points
                    case showControl:
                        {
                            for (int i =0; i < pointsList.Count; i++)
                            {
                                pointsList[i].PointToString();
                            }
                            break;
                        }
                    #endregion
                    #region Exit
                    case exitControl:
                        {
                            isExit = true; break;
                        }
                    #endregion
                    default: Instuctions(); break;
                }
            }
        }


        static void Instuctions()
            {
                Console.WriteLine("||To add new point enter 1,\n||to moove point enter 2,\n||to determine distance enter 3,\n||to show coordinats of one point 4,\n||to show all points enter 5,\n||to exit enter 6");
            }

        public static int ChangedLineInt()
        {
            string parameterSet;
            int parameterGet = 0;
            int number;
            bool canPars = false;

            do
            {
                parameterSet = Console.ReadLine();
                if (int.TryParse(parameterSet, out number))
                {
                    parameterGet = Convert.ToInt32(parameterSet);
                    canPars = true;
                }
                else
                {
                    Console.WriteLine("Only numbers");
                    canPars = false;
                }
            }
            while (!canPars);
            return parameterGet;
        }

    }
}
