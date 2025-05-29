using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolo_punkt
{
    class cpoint : point
    {
        private int _r;
        private int _g;
        private int _b;

        public int R
        {
            get { return _r; }
            set { _r = value; }
        }
        public int G
        {
            get { return _g; }
            set { _g = value; }
        }
        public int B
        {
            get { return _b; }
            set { _b = value; }
        }

        public cpoint() : base() { }
        public cpoint(double X, double Y, int r, int g, int b) : base(X, Y)
        {
            R = r;
            G = g;
            B = b;
        }
        public cpoint(double X, double Y, string N, int r, int g, int b) : base(X, Y, N)
        {
            R = r;
            G = g;
            B = b;
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine("Mój kolor to: (" + R + "," + G + "," + B + ")");
        }
    }
}
