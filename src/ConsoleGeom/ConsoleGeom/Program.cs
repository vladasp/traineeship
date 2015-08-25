using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGeom
{
    class Program
    {
        //Marker changes
        static void Main(string[] args)
        {
            Instuctions();
            Primitive p = new Primitive();
            ClassEvent CE = new ClassEvent();
            p.OnChangedLine += CE.ChangedLine;
            bool isExit = false;
            string input;

    while (isExit == false) {
        input = Console.ReadLine();
        switch (input) {

     case "R":
                        {
                            int[] Circle1 = new int[3]; int[] Circle2 = new int[3];
                            int[,] Triangle1 = new int[3, 4]; int[,] Triangle2 = new int[3, 4];
                            int[,] Square1 = new int[4, 4]; int[,] Square2 = new int[4, 4];

                            #region  First primitive
                            string prim1;
                            do
                            {
                                Console.WriteLine("Select first primitive (T - triangle, S -square, C - circle)");
                                prim1 = Console.ReadLine();
                                if (prim1 == "T") { Triangle1 = p.triangle(); }
                                else if (prim1 == "S") { Square1 = p.square(); }
                                else if (prim1 == "C") { Circle1 = p.circle(); }
                                else { Console.WriteLine("Value is entered incorrectly"); };
                            }
                            while (prim1 != "T" && prim1 != "S" && prim1 != "C");
                            #endregion

                            #region Second primitive
                            string prim2;
                            do
                            {
                                Console.WriteLine("Select second primitive (T - triangle, S -square, C - circle)");
                                prim2 = Console.ReadLine();
                                if (prim2 == "T") { Triangle2 = p.triangle(); }
                                else if (prim2 == "S") { Square2 = p.square(); }
                                else if (prim2 == "C") { Circle2 = p.circle(); }
                                else { Console.WriteLine("Value is entered incorrectly"); };
                            }
                            while (prim2 != "T" && prim2 != "S" && prim2 != "C");
                            #endregion

                            #region  Comparing primitives
                            if (prim1 == "C" && prim2 != "C" || prim1 != "C" && prim2 == "C")
                            {
                                if (prim1 == "C" && prim2 == "T")
                                {
                                    ComparingCL(Circle1, Triangle2);
                                }
                                if (prim1 == "C" && prim2 == "S")
                                {
                                    ComparingCL(Circle1, Square2);
                                }
                                if (prim2 == "C" && prim1 == "T")
                                {
                                    ComparingCL(Circle2, Triangle1);
                                }
                                if (prim2 == "C" && prim1 == "S")
                                {
                                    ComparingCL(Circle2, Square1);
                                }
                            }

                            if (prim1 == "C" && prim2 == "C")
                            {
                                ComparingCC(Circle1, Circle2);
                            }

                            if (prim1 != "C" && prim2 != "C")
                            {
                                if (prim1 == "T" && prim2 == "T")
                                {
                                    ComparingLL(Triangle1, Triangle2);
                                }
                                if (prim1 == "S" && prim2 == "S")
                                {
                                    ComparingLL(Square1, Square2);
                                }
                                if (prim1 == "T" && prim2 == "S")
                                {
                                    ComparingLL(Triangle1, Square2);
                                }
                                if (prim1 == "S" && prim2 == "T")
                                {
                                    ComparingLL(Square1, Triangle2);
                                }
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

        static public List<double> ComparingCL(int [] ARC, int[,] ARL)
        {
            double K=0; double L=0;
            double a; double b; double c;
            List<double> CompAr = new List<double>();
            double X1 = 0; double X2 = 0; double Y1 = 0; double Y2 = 0; double D = 0;

            for (int i = 0; i < (ARL.Length/4); i++)
            {
                int X11 = ARL[i, 0]; int Y11 = ARL[i, 1]; int X12 = ARL[i, 2]; int Y12 = ARL[i, 3];
                int dX = X12 - X11; int dY = Y12 - Y11;
                //Console.WriteLine("X11: {0}, Y11: {1}, X12: {2}, Y12: {3}", X11, Y11, X12, Y12);

                if (dX != 0 && dY != 0)
                    {
                        K = dX / dY; L = Y11 - (X11 * dY / dX);
                    }    
                else if (dY != 0 && dX == 0)
                    {
                        K = 0; L = X11;
                    }
                else if (dX != 0 && dY == 0)
                    {
                        K = 0; L = Y11;
                    }

                a = 1 + K * K;
                b = 2 * (K * L - ARC[1] - ARC[2] * K);
                c = L * L - 2 * ARC[1] * L + ARC[2] * ARC[2] + ARC[1] * ARC[1] - ARC[0] * ARC[0];

                D = Discrim(a, b, c)[0];
                if (D > 0)
                {
                    if (dX == 0)
                        {
                            Y1 = Discrim(a, b, c)[1]; X1 = K * Y1 + L;
                            Y2 = Discrim(a, b, c)[2]; X2 = K * Y2 + L;
                        }
                    else
                        {
                            X1 = Discrim(a, b, c)[1]; Y1 = K * X1 + L;
                            X2 = Discrim(a, b, c)[2]; Y2 = K * X2 + L;
                        }
                }
                if (D == 0)
                {
                    if (dX == 0)
                        {
                            Y1 = Discrim(a, b, c)[1]; X1 = K * Y1 + L;
                        }
                    else
                        {
                            X1 = Discrim(a, b, c)[1]; Y1 = K * X1 + L;
                        }
                }
                if (Y1 > Y11 && Y1 < Y12 || Y1 < Y11 && Y1 > Y12 || Y1 == Y11 || Y1 == Y12)
                {
                    if (X1 > X11 && X1 < X12 || X1 < X11 && X1 > X12 || X1 == X11 || X1 == X12)
                    {
                        CompAr.Add(X1);
                        CompAr.Add(Y1);
                        Console.WriteLine("X: {0}, Y: {1}", X1, Y1);
                    }
                }
                if (Y2 > Y11 && Y2 < Y12 || Y2 < Y11 && Y2 > Y12 || Y2 == Y11 || Y2 == Y12)
                {
                    if (X2 > X11 && X2 < X12 || X2 < X11 && X2 > X12 || X2 == X11 || X2 == X12)
                    {
                        CompAr.Add(X2);
                        CompAr.Add(Y2);
                        Console.WriteLine("X: {0}, Y: {1}", X2, Y2);
                    }
                }

            }

            if (CompAr.Count == 0)
            {
                Console.WriteLine("No comparing points");
            }

            return CompAr;
        }

        static public List<double> ComparingCC(int[] ARC1, int[] ARC2)
        {
            double Xp; double Yp; double E;
            double a; double b; double c;
            List<double> CompAr = new List<double>();

            Xp = ARC2[1] - ARC1[1];
            Yp = ARC2[2] - ARC1[2];
            E = (ARC2[0] * ARC2[0] - Xp * Xp - Yp * Yp - ARC1[0] * ARC1[0]) / (-2);

            a = Xp * Xp + Yp * Yp;
            b = -2 * Yp * E;
            c = E * E - Xp * Xp * ARC1[0] * ARC1[0];

            double D = Discrim(a, b, c)[0];
            double X1 = Discrim(a, b, c)[1];
            double X2 = Discrim(a, b, c)[2];
            //Console.WriteLine("D: {0} X1:{1} X2: {1}", D, X1, X2);

            if (D > 0)
                {
                    CompAr.Add((E - X1 * Yp) / Xp);
                    CompAr.Add(X1);
                    CompAr.Add((E - X2 * Yp) / Xp);
                    CompAr.Add(X2);
                    Console.WriteLine("X1: {0}, Y1: {1}, X2: {2}, Y2: {3}", CompAr[0], CompAr[1], CompAr[2], CompAr[3]);
                }
            if  (D == 0) 
                {
                    CompAr.Add(X1);
                    CompAr.Add((E - X1 * Yp) / Xp);
                    Console.WriteLine("X: {0}, Y: {1}", CompAr[0], CompAr[1]);
                }
            if (CompAr.Count == 0)
            {
                Console.WriteLine("No comparing points");
            }

            return CompAr;
        }

        static public List<double> ComparingLL(int[,] ARL1, int[,] ARL2)
        {
            double K1; double L1; double K2; double L2;
            double X = 0; double Y = 0;

            List<double> CompAr = new List<double>();

            for (int i = 0; i < (ARL1.Length / 4); i++)
            {
                for (int j = 0; j < (ARL2.Length / 4); j++)
                {
                    int X11 = ARL1[i, 0]; int Y11 = ARL1[i, 1]; int X12 = ARL1[i, 2]; int Y12 = ARL1[i, 3];
                    int X21 = ARL2[j, 0]; int Y21 = ARL2[j, 1]; int X22 = ARL2[j, 2]; int Y22 = ARL2[j, 3];
                    int dX1 = X12 - X11; int dY1 = Y12 - Y11;
                    int dX2 = X22 - X21; int dY2 = Y22 - Y21;
                    //Console.WriteLine("X11: {0}, Y11: {1}, X12: {2}, Y21: {3}, X21: {4}, Y21: {5}, X22: {6}, Y22: {7}", X11, Y11, X12, Y12, X21, Y21, X22, Y22);

                    // Without dY = 0 dX = 0
                    if (dX1 != 0 && dX2 != 0 && dY1 != 0 && dY2 != 0)
                        {
                            K1 = dY1 / dX1;
                            L1 = Y11 - (X11 * dY1 / dX1);
                            K2 = dY2 / dX2;
                            L2 = Y21 - (X21 * dY2 / dX2);
                            X = (K1 - (K2 / L2)) / (1 - (L1 / L2));
                            Y = K1 * X + L1;
                        }

                    // Without dY = 0
                    if (dX1 != 0 && dX2 != 0 && dY1 == 0 && dY2 != 0)
                        {
                            K1 = 0;
                            L1 = Y11;
                            K2 = dY2 / dX2;
                            L2 = Y21 - (X21 * dY2 / dX2);
                            X = (K1 - (K2 / L2)) / (1 - (L1 / L2));
                            Y = K1 * X + L1;
                        }
                    if (dX1 != 0 && dX2 != 0 && dY1 != 0 && dY2 == 0)
                        {
                            K1 = dY1 / dX1;
                            L1 = Y11 - (X11 * dY1 / dX1);
                            K2 = 0;
                            L2 = Y21;
                            X = (K1 - (K2 / L2)) / (1 - (L1 / L2));
                            Y = K1 * X + L1;
                        }
                    // Without dX = 0
                    if (dX1 == 0 && dX2 != 0 && dY1 != 0 && dY2 != 0)
                        {
                            K1 = 0;
                            L1 = X11;
                            K2 = dX2 / dY2;
                            L2 = X21 - (Y21 * dX2 / dY2);
                            Y = (K1 - (K2 / L2)) / (1 - (L1 / L2));
                            X = K1 * Y + L1;
                        }
                    if (dX1 != 0 && dX2 == 0 && dY1 != 0 && dY2 != 0)
                        {
                            K1 = dX1 / dY1;
                            L1 = X11 - (Y11 * dX1 / dY1);
                            K2 = 0;
                            L2 = X21;
                            Y = (K1 - (K2 / L2)) / (1 - (L1 / L2));
                            X = K1 * Y + L1;
                        }
                    // With Y = 0 X = 0;
                    if (dX2 == 0 && dY1 == 0)
                        {
                            X = X21;
                            Y = Y11;
                        }
                    if (dX1 == 0 && dY2 == 0)
                        {
                            X = X11;
                            Y = Y21;
                        }
            if (Y > Y11 && Y < Y12 || Y < Y11 && Y > Y12 || Y == Y11 || Y == Y12)
                {
                if (Y > Y21 && Y < Y22 || Y < Y21 && Y > Y22 || Y == Y21 || Y == Y22)
                    {
                        if (X > X11 && X < X12 || X < X11 && X > X12 || X == X11 || X == X12)
                        {
                            if (X > X21 && X < X22 || X < X21 && X > X22 || X == X21 || X == X22)
                            {
                                CompAr.Add(X);
                                CompAr.Add(Y);
                                Console.WriteLine("X1: {0}, Y1: {1}", X, Y);
                            }
                        }
                    }
                }
        }
    }

            if (CompAr.Count == 0)
                {
                    Console.WriteLine("No comparing points");
                }
            return CompAr;
        }

        static public double[] Discrim(double a, double b, double c)
        {
            double D;
            double Compx1 = 0;
            double Compx2 = 0;
            double[] Ar = new double[3]; 

            D = b *b - 4 * a * c;
            
                if (D >= 0)
                    {
                        Compx1 = (-b + Math.Sqrt(D)) / (2 * a);
                        Compx2 = (-b - Math.Sqrt(D)) / (2 * a);
                    }
            Ar[0] = D;
            Ar[1] = Compx1;
            Ar[2] = Compx2;
                //Console.WriteLine(D);
            return Ar;
        }

        static void Instuctions()
        {
            Console.Clear();
            Console.WriteLine("To run the program enter 'R', to exit enter 'E'");
        }

    }
}


