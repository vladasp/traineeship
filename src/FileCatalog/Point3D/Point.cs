using System;

namespace Point3D
{
    class Point
    {
        public delegate double DelegateType();
        public event DelegateType OnChangedLine;

        public double x; public double y; public double z;

        public void AddPoint()
        {
            Console.WriteLine("Enter coordinate X");
            x = OnChangedLine();
            Console.WriteLine("Enter coordinate Y");
            y = OnChangedLine();
            Console.WriteLine("Enter coordinate Z");
            z = OnChangedLine();
            return;
        }

        public void MooveTo()
        {
            double _x; double _y; double _z;
            double oldX; double oldY; double oldZ;
            oldX = x; oldY = y; oldZ = z;

            Console.WriteLine("Enter new X");
            _x = OnChangedLine();
            Console.WriteLine("Enter new Y");
            _y = OnChangedLine();
            Console.WriteLine("Enter new Z");
            _z = OnChangedLine();

            x = _x; y = _y; z = _z;
            Console.WriteLine("New x = {0} old x = {3}, new y {1} old y = {4}, new z {2} old z = {5}", x, y, z, oldX, oldY, oldZ);
            return;
        }

        public void PointToString()
        {
            string _x; string _y; string _z;
            _x = Convert.ToString(Math.Pow(x, 1));
            _y = Convert.ToString(Math.Pow(y, 1));
            _z = Convert.ToString(Math.Pow(z, 1));
            Console.WriteLine("String X = {0}, string Y = {1}, string Z = {2}", _x, _y, _z);
            return;
        }
    }
}
