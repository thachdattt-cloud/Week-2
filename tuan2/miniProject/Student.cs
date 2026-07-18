using System;

namespace tuan2.miniProject;

    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BirthYear { get; set; }
        public string ClassName { get; set; }
        public double MathScore { get; set; }
        public double PhysicsScore { get; set; }
        public double ChemistryScore { get; set; }

        public double CalculateAverageScore()
        {
            return (MathScore + PhysicsScore + ChemistryScore) / 3;
        }

        public string ClassifyRank()
        {
            double averageScore = CalculateAverageScore();

            if (averageScore >= 8.5)
            {
                return "Gioi";
            }
            else if (averageScore >= 7)
            {
                return "Kha";
            }
            else if (averageScore >= 5)
            {
                return "Trung binh";
            }
            else
            {
                return "Yeu";
            }
        }

        public override string ToString()
        {
            return $@"
Ma sinh vien   : {Id}
Ho ten         : {Name}
Nam sinh       : {BirthYear}
Lop hoc        : {ClassName}
Diem toan      : {MathScore}
Diem ly        : {PhysicsScore}
Diem hoa       : {ChemistryScore}
Diem TB        : {CalculateAverageScore():F2}
Xep loai       : {ClassifyRank()}
";
        }
    }
