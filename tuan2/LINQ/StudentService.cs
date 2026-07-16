// 2. FILE: StudentService.cs (Hoặc bạn viết luôn trong Program.cs)
namespace tuan2.LINQ
{
    internal class StudentService
    {
        // Đưa danh sách dữ liệu ra đây
        private List<Student> _students = new List<Student>
        {
            new Student(1, "An", 20, "K19", 8.5, "Nam"),
            new Student(2, "Binh", 19, "K19", 4.5, "Nam"),
            new Student(3, "Chi", 21, "K20", 7.0, "Nu"),
            new Student(4, "Dung", 22, "K20", 9.2, "Nu"),
            new Student(5, "Em", 18, "K19", 3.0, "Nam"),
            new Student(6, "tai", 22, "K20", 9.0, "Nam"),
        };




        public void Age_Condition1()
        {
            var list_age = _students.Where(s => s.Age >= 20).ToList();
            foreach (var st in list_age)
            {
                Console.WriteLine($"name : {st.Name} - {st.Age}");
            }
        }

        public void Class_Condition()
        {
            var list_Class = _students.Where(s => s.Class == "K19").ToList();
            foreach (var item in list_Class)
            {
                Console.WriteLine($"name : {item.Name} - {item.Class}");
            }
        }

        public void Show_Name() {
            
                List<string> names=_students.Select(s=>s.Name).ToList();
            Console.WriteLine(string.Join(" , ",names));
            } 

        public void Age_Condition2() {
            var list_Age2=_students.Where(s=>s.Age >=20)
                                    .Select(s=>s.Name)
                                    .ToList();
            foreach (var item in list_Age2)
            {
                Console.WriteLine($"{item}");
            }

        }
        
        public void Top3()
        {
            var top3 = _students.OrderByDescending(s => s.Score)
                              .Take(3)
                              .ToList();
            foreach (var item in top3)
            {
                Console.WriteLine($"name : {item.Name} - {item.Score}");
            }
        }
        public void sapxeplop()
        {
            var sapxep = _students.OrderBy(s => s.Class)
                                .ThenBy(s => s.Score)
                                .ToList();
            foreach (var item in sapxep)
            {
                Console.WriteLine($"{item.Class} - {item.Score}");
            }
        }
        public void nhomtheolop()
        {
            var nhom = _students.GroupBy(s => s.Class);
            foreach (var item in nhom)
            {
                Console.WriteLine($"class : {item.Key} - {item.Count()} (hoc sinh)");
            }
        }

        public void nhomtheodiem() 
        {
            var nhomdiem=_students.GroupBy(s =>
            {
                if (s.Score >= 8) return "gioi";
                else if (s.Score >= 7) return "kha";
                else return "trung binh";
            });
            foreach (var item in nhomdiem)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var item1 in item)
                {
                    Console.WriteLine($"{item1.Class} - {item1.Score}");
                }
            }
        }

        public void diemtrungbinhtunglop()
        {
            var nhom = _students.GroupBy(s => s.Class);
            foreach (var item in nhom)
            {
                var diemtrungbinh=item.Average(s=> s.Score);
                var diemcaonhat=item.MaxBy(s=> s.Score);
                var soluongsinhviendattren8 = item.Count(s => s.Score >= 8);
                Console.WriteLine($@"diem trung binh cua nhom {item.Key}
                                 - diem trung binh :{diemtrungbinh:0.00}
                                 - sinh vien cao nhat trong lop :{diemcaonhat.Name}
                                 - diem cua sinh vien la {diemcaonhat.Score}
");
                                 
            }
          
        }


        public void Combine()
        {
            while (true)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("0. dung chuong trinh");
                Console.WriteLine("1.loc theo tuoi (where) ");
                Console.WriteLine("2.loc theo lop ");
                Console.WriteLine("3.in  ten sinh vien");
                Console.WriteLine("4.loc theo tuoi (where + select)");
                Console.WriteLine("5.in ten va diem cua 3 sinh vien top dau");
                Console.WriteLine("6.sap xep theo lop va diem");
                Console.WriteLine("7.nhom theo lop");
                Console.WriteLine("8.nhom theo diem");
                Console.WriteLine("9.diem trung binh theo tung lop");
                Console.WriteLine("nhap lua chon :");
                Console.WriteLine("--------------------------------- ");
                int lc = int.Parse(Console.ReadLine());
                switch (lc)
                {

                    case 0:
                        return;

                    case 1:
                        Age_Condition1();
                        break;
                    case 2:
                        Class_Condition();
                        break;
                    case 3:
                        Show_Name();
                        break;
                    case 4:
                        Age_Condition2();
                        break;
                    case 5:
                        Top3();
                        break;
                    case 6:
                        sapxeplop();
                        break;
                    case 7:
                        nhomtheolop();
                        break;
                    case 8:
                        nhomtheodiem();
                        break;
                    case 9:
                        diemtrungbinhtunglop();
                        break;
                     
                    default:
                        Console.WriteLine("chon lai");
                        break;

                }
            }
        }
    }
}