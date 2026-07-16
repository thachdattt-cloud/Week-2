using System;

namespace tuan2.LINQ
{
    internal class LambdaDemo
    {
        public void Run()
        {
            Func<int, int, int> sum = (a, b) => a + b;
            Console.WriteLine("Check sum: " + sum(5, 7));

            Func<string, int> getNameLength = (name) => name.Length;
            Console.WriteLine("Check length name: " + getNameLength("quang dep trai"));

            Predicate<double> isPass = score => score >= 5;
            if (isPass(5))
            {
                Console.WriteLine("Pass");
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }
    }
}