using System;
using System.Collections.Generic;
using System.Linq;

namespace tuan2.LINQ
{
    internal class StudentService
    {
        private List<Student> _students = new List<Student>
        {
            new Student(1, "An", 20, "K19", 8.5, "Nam"),
            new Student(2, "Binh", 19, "K19", 4.5, "Nam"),
            new Student(3, "Chi", 21, "K20", 7.0, "Nu"),
            new Student(4, "Dung", 22, "K20", 9.2, "Nu"),
            new Student(5, "Em", 18, "K19", 3.0, "Nam"),
            new Student(6, "Tai", 22, "K20", 9.0, "Nam"),
        };

        // Where: lọc sinh viên từ 20 tuổi trở lên
        public void FilterByAge()
        {
            var studentsOverAge = _students.Where(s => s.Age >= 20).ToList();
            foreach (var student in studentsOverAge)
            {
                Console.WriteLine($"Name: {student.Name} - {student.Age}");
            }
        }

        // Where: lọc sinh viên theo lớp K19
        public void FilterByClass()
        {
            var k19Students = _students.Where(s => s.Class == "K19").ToList();
            foreach (var student in k19Students)
            {
                Console.WriteLine($"Name: {student.Name} - {student.Class}");
            }
        }

        // Select: chỉ lấy tên
        public void ShowStudentNames()
        {
            List<string> names = _students.Select(s => s.Name).ToList();
            Console.WriteLine(string.Join(" , ", names));
        }

        // Where + Select: tên của sinh viên từ 20 tuổi trở lên
        public void ShowNamesOfStudentsOverAge()
        {
            var names = _students.Where(s => s.Age >= 20)
                                  .Select(s => s.Name)
                                  .ToList();
            foreach (var name in names)
            {
                Console.WriteLine($"{name}");
            }
        }

        // OrderByDescending + Take: top 3 điểm cao nhất
        public void ShowTop3Students()
        {
            var top3 = _students.OrderByDescending(s => s.Score)
                                 .Take(3)
                                 .ToList();
            foreach (var student in top3)
            {
                Console.WriteLine($"Name: {student.Name} - {student.Score}");
            }
        }

        // OrderBy + ThenBy: sắp xếp theo lớp rồi theo điểm
        public void SortByClassAndScore()
        {
            var sortedStudents = _students.OrderBy(s => s.Class)
                                           .ThenBy(s => s.Score)
                                           .ToList();
            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"{student.Class} - {student.Score}");
            }
        }

        // GroupBy: nhóm theo lớp
        public void GroupByClass()
        {
            var groupedByClass = _students.GroupBy(s => s.Class);
            foreach (var group in groupedByClass)
            {
                Console.WriteLine($"Class: {group.Key} - {group.Count()} students");
            }
        }

        // GroupBy: nhóm theo mức điểm
        public void GroupByScoreLevel()
        {
            var groupedByScore = _students.GroupBy(s =>
            {
                if (s.Score >= 8) return "Gioi";
                else if (s.Score >= 7) return "Kha";
                else return "TrungBinh";
            });

            foreach (var group in groupedByScore)
            {
                Console.WriteLine($"{group.Key}");
                foreach (var student in group)
                {
                    Console.WriteLine($"{student.Class} - {student.Score}");
                }
            }
        }

        // GroupBy + Aggregate: thống kê theo từng lớp
        public void ShowClassStatistics()
        {
            var groupedByClass = _students.GroupBy(s => s.Class);
            foreach (var group in groupedByClass)
            {
                var averageScore = group.Average(s => s.Score);
                var topStudent = group.MaxBy(s => s.Score);
                var passCount = group.Count(s => s.Score >= 8);

                Console.WriteLine($@"Statistics for class {group.Key}
                                 - Average score: {averageScore:0.00}
                                 - Top student: {topStudent.Name}
                                 - Top score: {topStudent.Score}
");
            }
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("0. Thoat chuong trinh");
                Console.WriteLine("1. Loc theo tuoi (Where)");
                Console.WriteLine("2. Loc theo lop");
                Console.WriteLine("3. In ten sinh vien");
                Console.WriteLine("4. Loc theo tuoi (Where + Select)");
                Console.WriteLine("5. In ten va diem cua 3 sinh vien top dau");
                Console.WriteLine("6. Sap xep theo lop va diem");
                Console.WriteLine("7. Nhom theo lop");
                Console.WriteLine("8. Nhom theo diem");
                Console.WriteLine("9. Diem trung binh theo tung lop");
                Console.WriteLine("Nhap lua chon:");
                Console.WriteLine("--------------------------------- ");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        return;
                    case 1:
                        FilterByAge();
                        break;
                    case 2:
                        FilterByClass();
                        break;
                    case 3:
                        ShowStudentNames();
                        break;
                    case 4:
                        ShowNamesOfStudentsOverAge();
                        break;
                    case 5:
                        ShowTop3Students();
                        break;
                    case 6:
                        SortByClassAndScore();
                        break;
                    case 7:
                        GroupByClass();
                        break;
                    case 8:
                        GroupByScoreLevel();
                        break;
                    case 9:
                        ShowClassStatistics();
                        break;
                    default:
                        Console.WriteLine("Chon lai");
                        break;
                }
            }
        }
    }
}