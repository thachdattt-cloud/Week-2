using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.Interface
{
    internal interface IPayable
    {
        public double CalculatePayment();
        public void show()
        {
            Console.WriteLine($"hoc sinh nhan hoc bong pahi tra {CalculatePayment()}");
        }

        
    }

    public interface Reportable
    {
        public string GetReport();
        public void show2()
        {
            Console.WriteLine($"thong tin : {GetReport()}");
        }
    }
}
