using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using tuan2.QuanLyNhanVien;

namespace tuan2.miniProject;

    internal class StudentService : ICrudService<Student>
    {
        private List<Student> _danhSachSinhVien = new List<Student>();
        private HashSet<int> _dsMaSinhVien = new HashSet<int>();

        // ---------- CRUD co ban (ICrudService) ----------

        public bool Add(Student item)
        {
            if (_dsMaSinhVien.Contains(item.Id))
                return false;

            _danhSachSinhVien.Add(item);
            _dsMaSinhVien.Add(item.Id);
            return true;
        }

        public int Remove(int id)
        {
            int soLuongDaXoa = _danhSachSinhVien.RemoveAll(s => s.Id == id);
            if (soLuongDaXoa > 0)
                _dsMaSinhVien.Remove(id);

            return soLuongDaXoa;
        }

        public List<Student> GetAll()
        {
            return _danhSachSinhVien;
        }

      

        public int RemoveByName(string name)
        {
            var sinhVienCanXoa = _danhSachSinhVien.Where(s => s.Name == name).ToList();
            foreach (var sv in sinhVienCanXoa)
                _dsMaSinhVien.Remove(sv.Id);

            return _danhSachSinhVien.RemoveAll(s => s.Name == name);
        }

        public bool Update(int id, Student newData)
        {
            var sinhVien = _danhSachSinhVien.FirstOrDefault(s => s.Id == id);
            if (sinhVien == null)
                return false;

            sinhVien.Name = newData.Name;
            sinhVien.BirthYear = newData.BirthYear;
            sinhVien.ClassName = newData.ClassName;
            sinhVien.MathScore = newData.MathScore;
            sinhVien.PhysicsScore = newData.PhysicsScore;
            sinhVien.ChemistryScore = newData.ChemistryScore;
            return true;
        }

        public bool IsMaSinhVienTonTai(int id)
        {
            return _dsMaSinhVien.Contains(id);
        }

        // ---------- LINQ: tim kiem, sap xep, thong ke ----------

        public List<Student> SearchByExactName(string name)
        {
            return _danhSachSinhVien.Where(s => s.Name == name).ToList();
        }

        public List<Student> SearchByPartialName(string keyword)
        {
            return _danhSachSinhVien
                .Where(s => s.Name.ToLower().Contains(keyword.ToLower()))
                .ToList();
        }

        public List<Student> GetSortedByScoreAscending()
        {
            return _danhSachSinhVien.OrderBy(s => s.CalculateAverageScore()).ToList();
        }

        public Student GetTopStudent()
        {
            // MaxBy can .NET 6+. Neu project dung ban cu hon, thay bang:
            // _danhSachSinhVien.OrderByDescending(s => s.CalculateAverageScore()).FirstOrDefault();
            return _danhSachSinhVien.MaxBy(s => s.CalculateAverageScore());
        }

        public Student GetLowestStudent()
        {
            return _danhSachSinhVien.MinBy(s => s.CalculateAverageScore());
        }

        public double GetClassAverage()
        {
            if (_danhSachSinhVien.Count == 0)
            {
                return 0;
            }
            else
            {
                return _danhSachSinhVien.Average(s => s.CalculateAverageScore());
            }
        }

        public Dictionary<string, int> GetStatisticsByRank()
        {
            return _danhSachSinhVien
                .GroupBy(s => s.ClassifyRank())
                .ToDictionary(g => g.Key, g => g.Count());
        }

        // ---------- Async: luu/tai du lieu tu file ----------

        public async Task SaveToFileAsync(string duongDan)
        {
            List<string> cacDong = new List<string>();

            foreach (var sv in _danhSachSinhVien)
            {
                string motDong = sv.Id + "|" + sv.Name + "|" + sv.BirthYear + "|" + sv.ClassName + "|" + sv.MathScore + "|" + sv.PhysicsScore + "|" + sv.ChemistryScore;
                cacDong.Add(motDong);
            }

            await File.WriteAllLinesAsync(duongDan, cacDong);
        }

        public async Task LoadFromFileAsync(string duongDan)
        {
            if (!File.Exists(duongDan))
            {
                Console.WriteLine("Chua co file du lieu, bo qua buoc tai.");
                return;
            }

            string[] cacDong = await File.ReadAllLinesAsync(duongDan);

            _danhSachSinhVien.Clear();
            _dsMaSinhVien.Clear();

            foreach (var dong in cacDong)
            {
                if (string.IsNullOrWhiteSpace(dong))
                {
                    continue;
                }

                string[] phan = dong.Split('|');

                Student sv = new Student();
                sv.Id = int.Parse(phan[0]);
                sv.Name = phan[1];
                sv.BirthYear = int.Parse(phan[2]);
                sv.ClassName = phan[3];
                sv.MathScore = double.Parse(phan[4]);
                sv.PhysicsScore = double.Parse(phan[5]);
                sv.ChemistryScore = double.Parse(phan[6]);

                _danhSachSinhVien.Add(sv);
                _dsMaSinhVien.Add(sv.Id);
            }
        }
    }
