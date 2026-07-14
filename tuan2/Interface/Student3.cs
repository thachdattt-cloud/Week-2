using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.Interface
{
    internal class Student3 : IPayable
    {
        public int Scholarship {  get; set; }

        public Student3(int scholarship)
        {
            Scholarship = scholarship;
        }

        public  double CalculatePayment()
        {
            return Scholarship - 1000000;
        }
    }
}
