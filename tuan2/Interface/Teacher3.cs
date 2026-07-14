using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.Interface
{
    internal class Teacher3 : IPayable , Reportable
    {
        public int Salary { get; set; }
        public string Name { get; set; }
        public Teacher3(int salary,string name)
        {
            Salary = salary;
            Name=name;
        }

        public double CalculatePayment()
        {
            return Salary - 2000000;
        }
        public string GetReport()
        {
            return $"giáo viên {Name} phai tra khoan la : {CalculatePayment()}";
        }

    }
}
