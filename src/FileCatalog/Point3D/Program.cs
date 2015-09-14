using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{ enum Control {M = 1, C, E}
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> pointsList = new List<Point>();
            Point point = new Point();
            Control control = new Control();
            bool isExit = false;
            string input;
            int countPoints;
            int indexPoint;

            Console.WriteLine("Enter count of points from 1 to 5");
            countPoints = (int)point.ChangedConsoleLine();
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
                Enum.TryParse(input, true, out control);
                switch (control)
                {
                    case Control.M:
                            Console.WriteLine("Enter the point you what to moove");
                            do
                            {
                                indexPoint = (int)point.ChangedConsoleLine();
                                if (indexPoint > countPoints || indexPoint < 1)
                                    Console.WriteLine("Index point out of range");
                                else
                                    pointsList[indexPoint-1].MooveTo();
                            }
                            while (indexPoint > countPoints || indexPoint < 1);
                            break;
                    case Control.C:
                            Console.WriteLine("Enter the point you what to see");
                            do
                            {
                                indexPoint = (int)point.ChangedConsoleLine();
                                if (indexPoint > countPoints || indexPoint < 1)
                                    Console.WriteLine("Index point out of range");
                            }
                            while (indexPoint > countPoints || indexPoint < 1);
                            pointsList[indexPoint-1].PointToString();
                            break;
                    case Control.E: isExit = true; break;
                    default: Instuctions(); break;
                }
            }
        }
        static void DistanceTo(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Round(Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2) + Math.Pow((z1 - z2), 2)), 2);
            Console.WriteLine("Distanse distance between the points {0}", distance);
            return;
        }
        static void StringTo (double x1, double y1, double z1)
        {
            string x = Convert.ToString(x1);
            string y = Convert.ToString(y1);
            string z = Convert.ToString(z1);
            Console.WriteLine("Сoordinate X  {0}", x);
            Console.WriteLine("Сoordinate Y  {0}", y);
            Console.WriteLine("Сoordinate Z  {0}", z);
            return;
        }
        static void Instuctions()
            {
                Console.WriteLine("To moove point {0}, to show coordinats {1}, to exit enter {2}", 
                    Control.M.ToString(), Control.C.ToString(), Control.E.ToString());
            }
    }
}
