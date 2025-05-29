using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolo_punkt
{
    class Circle
    {
        private double r;
        private point center;
        public Circle(double R, point P)
        {
            r = R;
            center = P;
        }
        public Circle(double R, double A, double B)
        {
            r = R;
            center = new point();
            set_center(A, B);
        }
        public double perimeter()
        {
            return 2 * r * Math.PI;
        }
        public double area()
        {
            return r * r * Math.PI;
        }
        public void set_center(double X, double Y)
        {
            center.set_x(X);
            center.set_y(Y);
        }
        public point get_center()
        {
            return center;
        }
        public double get_r()
        {
            return r;
        }
        public void set_r(double R)
        {
            r = R;
        }
    }
}
