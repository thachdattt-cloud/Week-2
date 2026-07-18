using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.asyn_task_await
{
    internal class Test
    {

        public async Task<int> TinhTongAsync(int a, int b)
        {
            await Task.Delay(3000);  
            return a + b;
        }

        public async Task<double>BinhphuongAsync(double a, double b)
        {
            await Task.Delay(6000);
            return a * b;
        }
        public async Task<string> nameAsync(string ten)
        {
            await Task.Delay(3999);
            return ten;
        }

   
        public async Task handle()
        {
            Console.WriteLine("hello");
            int ketQua = await TinhTongAsync(3, 5);
           
            Console.WriteLine(ketQua);

            //double ketqua2 = await BinhphuongAsync(5, 8);
            //Console.WriteLine(ketqua2);

            var ketqua4 = nameAsync("qaung dep trai hehehe");
            Console.WriteLine(ketqua4);

            string ketqua3 = await nameAsync("qaung dep trai hehehe");
            Console.WriteLine(ketqua3);
        }
    }
}
