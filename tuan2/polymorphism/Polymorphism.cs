using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tuan2.Abstraction;
namespace tuan2.polymorphism
{
    internal class Polymorphism
    {
        List<Shape> Shapes = new List<Shape>
        {
            new Circle(5),
            new Rectangle(4,6)

        };
        
         public void run()
        {
            foreach (var shape in Shapes)
            {
                shape.Info();
            }
        }


    }
}
