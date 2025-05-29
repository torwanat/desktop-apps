using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolo_punkt
{
    class point
    {
        private double x;
        private double y;
        public string name { get; set; }

        public point() { }
        public point(double X, double Y)
        {
            x = X;
            y = Y;
        }
        public point(double X, double Y, string N)
        {
            x = X;
            y = Y;
            name = N;
        }
        public void set_x(double X)
        {
            x = x;
        }
        public double get_x()
        {
            return x;
        }
        public void set_y(double Y)
        {
            y = Y;
        }
        public double get_y()
        {
            return y;
        }

        public virtual void Info()
        {
            Console.WriteLine("Jestem punkt " + name + "o współrzędnych: " + x + "," + y);
        }
    }
}
