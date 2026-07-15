
//using tuan2.Abstraction;
//using tuan2.Inheritance;
//using tuan2.Interface;
using tuan2.QuanLyNhanVien;
namespace tuan2
{

    public class Program
    {
        static void Main(string[] args)
        {

            //Bai2 k=new Bai2();
            //k.Run();

            //Student st=new Student();
            //      st.show();

            //PartTimeTeacher x = new PartTimeTeacher("quang",21,"math",2500000,3);
            //x.show();


            //Shape x = new Circle(4.3);
            //Shape y = new Rectangle(5, 9);

            //x.Info();

            //Employee x = new Intern("quang",1500000,3);
            //Employee y = new FullTimeEmployee("quang2", 5000000, 7);

            //x.ShowInter();
            //y.ShowFullTimeEmployee();

            //IPayable x = new Student3(5000000);
            //Reportable y = new Teacher3( 10000000,"quang");

            //x.show();
            //y.show2();

            var service = new EmployeeService();
            service.Add(new FullTimeEmployee("An", 1, 10000000));
            service.Add(new PartTimeEmployee("Bình", 2, 100000, 80));
            service.Add(new Manager("Hoa", 3, 20000000, 5000000));

            service.DisplayInfo();

        }
    }
}
