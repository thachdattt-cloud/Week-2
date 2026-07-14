using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.Abstraction
{
    internal class Circle : Shape
    {

        public double Radius {  get; set; }


        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Radius * Radius * 3.14;
        }
        public override double CalculatePerimeter()
        {
            return 2 * 3.14 * Radius;
        }
    }
}
