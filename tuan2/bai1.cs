using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2
{
    internal class bai1
    {
        public string ten {  get; set; }
        private double gpa {  get; set; }

        public double Gpa
        {
            get  => gpa; 
            // get{return gpa;}
            set
            {
                if (value > 0 && value <= 4.0) gpa = value;
                else gpa = 0;
            }
        }
        public bai1(string ten,double gpa)
        {
            this.ten = ten;
            this.gpa = gpa;
        }
    }
}
