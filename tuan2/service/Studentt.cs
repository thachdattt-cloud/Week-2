using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.service
{
    internal class Studentt
    {
        private int _id {  get; set; }
        private string _name { get; set; }
        private int _age { get; set; }
        private string _class {  get; set; }
        private double _score {  get; set; }

        public Studentt()
        {
            _id = 0;
            _name = "khong co ten";
            _age = 0;
            _class = "chua co lop";
            _score = 0;
        }

        public Studentt(int id,string name, int age, string @class, double score)
        {
            Id = id;
            Name = name;
            Age = age;
            _class = @class;
            Score = score;
        }

        //

        public  int Id
        {
            get => _id;
            set
            {
                if (value > 0) _id = value;
                else throw new ArgumentException("id phai lon hon 0");
            }
        }

        public string Name {
            get => _name;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("ten khong dupc de trong");
                }
                else _name = value;

            }

        }

        public int Age
        {

            get => _age;
            set
            {
                if (value > 0) _age = value;
                else throw new ArgumentException("tuoi phai lon hon 0");
            }

        }
        public string Class
        {
            get => _class;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("class khong dupc de trong");
                }
                else _class = value;

            }
        }

        public double Score{
        get => _score;
            set
            {
                if (value > 0 && value <= 10) _score = value;
                else throw new ArgumentException("diem phai nam trong khoang tu 0 den 10");

            }
        
        }


    }
}
