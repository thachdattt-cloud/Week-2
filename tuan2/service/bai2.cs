using System;

namespace tuan2.service
{
    internal class Bai2
    {
        // Hàm nhập liệu từ Console, trả về 1 Student
        private  Studentt NhapSinhVien()
        {
            Console.WriteLine("Id :");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Ten :");
            string name = Console.ReadLine();

            Console.WriteLine("Tuoi :");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Lop :");
            string studentClass = Console.ReadLine();

            Console.WriteLine("Diem :");
            double score = double.Parse(Console.ReadLine());

            return new Studentt(id, name, age, studentClass, score);
        }

        // Hàm in danh sách sinh viên
        private static void InDanhSach(StudentService service)
        {
            Console.WriteLine("\n--- Danh sách sinh viên ---");
            foreach (var s in service.GetAllStudent())
            {
                Console.WriteLine($"{s.Id} - {s.Name} - {s.Age} - {s.Class} - {s.Score}");
            }
        }

        // Hàm chạy toàn bộ demo của bài 2, được Program gọi vào
        public  void Run()
        {
            StudentService service = new StudentService();

            Console.WriteLine("=== BÀI 2: Class, Encapsulation ===");

            bool tiepTuc = true;
            while (tiepTuc)
            {
                Console.WriteLine("\n1. Thêm sinh viên");
                Console.WriteLine("2. Xóa sinh viên");
                Console.WriteLine("3. Xem danh sách");
                Console.WriteLine("0. Thoát bài 2");
                Console.Write("Chọn: ");
                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                        Studentt st = NhapSinhVien();
                        service.AddStudent(st);
                        Console.WriteLine("Thêm thành công");
                        break;

                    case "2":
                        Console.Write("Nhập id cần xóa: ");
                        int id = int.Parse(Console.ReadLine());
                        service.RemoveStudent(id);
                        break;

                    case "3":
                        InDanhSach(service);
                        break;

                    case "0":
                        tiepTuc = false;
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ");
                        break;
                }
            }
        }
    }
}