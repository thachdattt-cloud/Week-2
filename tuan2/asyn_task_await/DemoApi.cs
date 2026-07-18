using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan2.asyn_task_await
{
    internal class DemoApi
    {

        public async Task<List<string>> LoadStudentsFromDbAsync()
        {
            Console.WriteLine("dang ket noi toi database");
            await Task.Delay(5000);
            Console.WriteLine("da lay thanh cong du lieu hoc sinh");
            return new List<string> { "quang", "lan", "huyen", "hanh" };
        }
        public async Task<List<string>> LoadTeachersFromDbAsync()
        {
            Console.WriteLine("Đang ket noi toi DB (...");
            await Task.Delay(1500);
            Console.WriteLine("da lay thanh cong du lieu giao vien");

            return new List<string> { "Co Lan", "Thay Nam" };
        }
        public async Task run()
        {
            Console.WriteLine("dang tai du lieu");
            List<string> chuoi = await LoadStudentsFromDbAsync();
            Console.WriteLine(chuoi[0]);

            Console.WriteLine("do thoi gian khi chay 2 task song song");

            var stopWatch = Stopwatch.StartNew();
            var studentTask = LoadStudentsFromDbAsync();
            var teacherTask= LoadTeachersFromDbAsync();

            await Task.WhenAll(studentTask, teacherTask);
            stopWatch.Stop();
            Console.WriteLine("thoi gian chay song song uoc tinh la : "+stopWatch.ElapsedMilliseconds);
        }
    }
}
