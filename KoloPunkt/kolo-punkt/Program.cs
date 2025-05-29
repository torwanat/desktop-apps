using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolo_punkt
{
    class Program
    {
        static void Main(string[] args)
        {
            point point1;
            point1 = new point(2, 3, "A");
            point1.Info();
            point1.set_x(5);
            point1.Info();
            Circle circle1 = new Circle(5, point1);

            Console.WriteLine("Środek: x = " + circle1.get_center().get_x() + ", y = " + circle1.get_center().get_y());
            Console.WriteLine("Promień: r = " + circle1.get_r());
            Console.WriteLine("Pole: " + circle1.area());
            Console.WriteLine("Obwód: " + circle1.perimeter());
        }
    }
}
