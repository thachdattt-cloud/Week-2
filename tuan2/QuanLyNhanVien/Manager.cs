using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.QuanLyNhanVien
{
    internal class Manager : FullTimeEmployee
    {
        public double bonus {  get; set; }


        public Manager(string name,int id,double baseSalary,double bonus) : base(name,id,baseSalary)
        {
            this.bonus = bonus;
        }
        public override double CalculateSalary()
        {
            return base.CalculateSalary() + bonus;
        }
    }
}
