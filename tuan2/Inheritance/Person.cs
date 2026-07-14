using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.Inheritance
{
    internal class Person
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age= age;
        }

        public virtual void show()
        {
            Name = "quang";
            Age= 21;
            Console.WriteLine($"toi ten la {Name} toi nam nay {Age}");
        }
        public Person()
        {

        }


    }
}
