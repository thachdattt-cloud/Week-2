
//using tuan2.Abstraction;
//using tuan2.Inheritance;
//using tuan2.Interface;
using System.Diagnostics.CodeAnalysis;
using tuan2.LINQ;
using tuan2.QuanLyNhanVien;
using tuan2.asyn_task_await;
using System.Reflection.Metadata;
namespace tuan2
{

    public class Program
    {
        static async Task Main(string[] args)
        {
            // folder Service
            //Bai2 k=new Bai2();
            //k.Run();

            //folder
            //Student st=new Student();
            //      st.show();

            //PartTimeTeacher x = new PartTimeTeacher("quang",21,"math",2500000,3);
            //x.show();

            //folder polymorphism
            //Shape x = new Circle(4.3);
            //Shape y = new Rectangle(5, 9);
            //x.Info();

            // folder Abstraction
            //Employee x = new Intern("quang",1500000,3);
            //Employee y = new FullTimeEmployee("quang2", 5000000, 7);
            //x.ShowInter();
            //y.ShowFullTimeEmployee();

            //folder Interface
            //IPayable x = new Student3(5000000);
            //Reportable y = new Teacher3( 10000000,"quang");
            //x.show();
            //y.show2();

            // folder quanlynhanvien
            //var service = new EmployeeService();
            //service.Add(new FullTimeEmployee("An", 1, 10000000));
            //service.Add(new PartTimeEmployee("Bình", 2, 100000, 80));
            //service.Add(new Manager("Hoa", 3, 20000000, 5000000));
            //service.DisplayInfo();

            //LINQ
            //LambdaDemo x=new LambdaDemo();
            //x.Run();
            //StudentService y=new StudentService();
            //y.ShowMenu();

            //Async_task_await
            //Test x = new Test();
            // await x.handle();
            //DemoApi y = new DemoApi();
            //await y.run();
          //  cancellationToken z = new cancellationToken();
          //await  z.RunAsync();
          Main k=new Main();
            await k.RunAsync(); 

        }
    }
}
