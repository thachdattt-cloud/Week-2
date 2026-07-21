
//using tuan2.Abstraction;
//using tuan2.Inheritance;
//using tuan2.Interface;
using System.Diagnostics.CodeAnalysis;
//using tuan2.LINQ;
//using tuan2.QuanLyNhanVien;
//using tuan2.asyn_task_await;
using tuan2.miniProject;
using System.Reflection.Metadata;


namespace tuan2
{

    public class Program
    {
        //static async Task Main(string[] args)
        //{
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
        //Main k = new Main();
        //await k.RunAsync();

        //}

        //*************************MINI_PROJECT***********************************

        private static StudentService _studentService = new StudentService();
        private const string DuongDanFile = "danhsachsinhvien.txt";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Dang tai du lieu...");
            await _studentService.LoadFromFileAsync(DuongDanFile);
            Console.WriteLine("Tai du lieu xong!");

            await HienThiMenuAsync();
        }

        private static double NhapDiem(double min, double max)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double giaTri) && giaTri >= min && giaTri <= max)
                    return giaTri;

                Console.WriteLine($"Gia tri phai tu {min} den {max}, nhap lai:");
            }
        }

        private static int NhapSoNguyen(int min)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int giaTri) && giaTri >= min)
                    return giaTri;

                Console.WriteLine($"Gia tri phai lon hon hoac bang {min}, nhap lai:");
            }
        }



        private static void ThemSinhVien()
        {
            Student sinhVien = new Student();
            Console.WriteLine("--- Nhap thong tin sinh vien ---");

            Console.Write("Ma sinh vien: ");
            while (true)
            {
                sinhVien.Id = NhapSoNguyen(1);
                if (_studentService.IsMaSinhVienTonTai(sinhVien.Id))
                {
                    Console.WriteLine("Ma sinh vien da ton tai, nhap lai: ");
                }
                else
                {
                    break;
                }
            }

            Console.Write("Ho ten: ");
            while (true)
            {
                sinhVien.Name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(sinhVien.Name))
                {
                    Console.WriteLine("Ho ten khong duoc de trong, nhap lai: ");
                }
                else
                {
                    break;
                }
            }

            Console.Write("Nam sinh: ");
            sinhVien.BirthYear = NhapSoNguyen(2000);

            Console.Write("Lop hoc: ");
            sinhVien.ClassName = Console.ReadLine();

            Console.Write("Diem toan: ");
            sinhVien.MathScore = NhapDiem(0, 10);

            Console.Write("Diem ly: ");
            sinhVien.PhysicsScore = NhapDiem(0, 10);

            Console.Write("Diem hoa: ");
            sinhVien.ChemistryScore = NhapDiem(0, 10);

            _studentService.Add(sinhVien);
            Console.WriteLine("Them sinh vien thanh cong!");
        }

        private static void XoaSinhVien()
        {
            Console.Write("Nhap ho ten sinh vien can xoa: ");
            string ten = Console.ReadLine();
            int soLuongDaXoa = _studentService.RemoveByName(ten);

            if (soLuongDaXoa > 0)
            {
                Console.WriteLine($"Da xoa {soLuongDaXoa} sinh vien");
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien can xoa");
            }
        }

        private static void SuaSinhVien()
        {
            Console.Write("Nhap ma sinh vien can sua: ");
            int id = NhapSoNguyen(1);

            Console.WriteLine("Nhap thong tin moi:");
            Student duLieuMoi = new Student();

            Console.Write("Ho ten moi: ");
            duLieuMoi.Name = Console.ReadLine();

            Console.Write("Nam sinh moi: ");
            duLieuMoi.BirthYear = NhapSoNguyen(2000);

            Console.Write("Lop hoc moi: ");
            duLieuMoi.ClassName = Console.ReadLine();

            Console.Write("Diem toan moi: ");
            duLieuMoi.MathScore = NhapDiem(0, 10);

            Console.Write("Diem ly moi: ");
            duLieuMoi.PhysicsScore = NhapDiem(0, 10);

            Console.Write("Diem hoa moi: ");
            duLieuMoi.ChemistryScore = NhapDiem(0, 10);

            bool daSua = _studentService.Update(id, duLieuMoi);
            if (daSua)
            {
                Console.WriteLine("Cap nhat thanh cong");
            }
            else
            {
                Console.WriteLine("Khong tim thay ma sinh vien can sua");
            }
        }

        private static void InDanhSach()
        {
            var danhSach = _studentService.GetAll();
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sach rong");
                return;
            }

            foreach (var sinhVien in danhSach)
                Console.WriteLine(sinhVien);
        }

        private static void TimKiemTheoTen()
        {
            Console.Write("Nhap ho ten can tim (gan dung): ");
            string tuKhoa = Console.ReadLine();
            var ketQua = _studentService.SearchByPartialName(tuKhoa);

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Khong tim thay sinh vien nao");
            }
            else
            {
                foreach (var sinhVien in ketQua)
                    Console.WriteLine(sinhVien);
            }
        }

        private static void SapXepTheoDiem()
        {
            var danhSachDaSapXep = _studentService.GetSortedByScoreAscending();
            foreach (var sinhVien in danhSachDaSapXep)
                Console.WriteLine(sinhVien);
        }

        private static void ThongKe()
        {
            Console.WriteLine($"Diem trung binh ca lop: {_studentService.GetClassAverage():F2}");

            var sinhVienGioiNhat = _studentService.GetTopStudent();
            var sinhVienKemNhat = _studentService.GetLowestStudent();

            if (sinhVienGioiNhat != null)
                Console.WriteLine($"Sinh vien diem cao nhat: {sinhVienGioiNhat.Name} ({sinhVienGioiNhat.CalculateAverageScore():F2})");

            if (sinhVienKemNhat != null)
                Console.WriteLine($"Sinh vien diem thap nhat: {sinhVienKemNhat.Name} ({sinhVienKemNhat.CalculateAverageScore():F2})");

            Console.WriteLine("Thong ke xep loai:");
            var thongKe = _studentService.GetStatisticsByRank();
            foreach (var kvp in thongKe)
                Console.WriteLine($"{kvp.Key}: {kvp.Value} sinh vien");
        }

        private static async Task HienThiMenuAsync()
        {
            while (true)
            {
                Console.WriteLine("\n----------------- MENU -----------------");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Xoa sinh vien");
                Console.WriteLine("3. Sua sinh vien");
                Console.WriteLine("4. In danh sach");
                Console.WriteLine("5. Tim kiem theo ten");
                Console.WriteLine("6. Sap xep theo diem");
                Console.WriteLine("7. Thong ke");
                Console.WriteLine("8. Luu du lieu");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon: ");

                int luaChon = NhapSoNguyen(0);
                switch (luaChon)
                {
                    case 1:
                        ThemSinhVien();
                        break;
                    case 2:
                        XoaSinhVien();
                        break;
                    case 3:
                        SuaSinhVien();
                        break;
                    case 4:
                        InDanhSach();
                        break;
                    case 5:
                        TimKiemTheoTen();
                        break;
                    case 6:
                        SapXepTheoDiem();
                        break;
                    case 7:
                        ThongKe();
                        break;
                    case 8:
                        Console.WriteLine("Dang luu du lieu...");
                        await _studentService.SaveToFileAsync(DuongDanFile);
                        Console.WriteLine("Da luu xong!");
                        break;
                    case 0:
                        Console.WriteLine("Dang luu du lieu truoc khi thoat...");
                        await _studentService.SaveToFileAsync(DuongDanFile);
                        Console.WriteLine("Tam biet!");
                        return;
                    default:
                        Console.WriteLine("Lua chon khong hop le, chon lai:");
                        break;
                }
            }
        }
    }
}

