using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.Abstraction
{
    internal class FullTimeEmployee : Employee
    {
        public int RateBonus{  get; set; }

        public FullTimeEmployee(string name,double baseSalary,int rateBonus) : base(name, baseSalary)
        {
            RateBonus = rateBonus;
        }

        public override double CalculateBonus()
        {
            return RateBonus * BaseSalary;
        }

    }
}
