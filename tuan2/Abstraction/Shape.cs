using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.Abstraction
{
    internal abstract class Shape
    {
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();

        public void Info()
        {
            Console.WriteLine($"dien tich {CalculateArea()}");
            Console.WriteLine($"chu vi : {CalculatePerimeter()}");
        }


    }
}
