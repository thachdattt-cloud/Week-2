using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.QuanLyNhanVien
{
    internal class FullTimeEmployee : Employee
    {
     public double BaseSalary {  get; set; }

        public FullTimeEmployee(string name,int id,double baseSalary):base(name,id)
        {
            BaseSalary = baseSalary;
        }

        public override double CalculateSalary()
        {
            return BaseSalary;
        }
    }
}
