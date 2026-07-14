Ngày 1 — Class, Encapsulation

Nội dung đã học


Class, Object, Constructor (constructor đầy đủ tham số + constructor mặc định)
Property với validate logic (get/set), phân biệt với Field thường
Encapsulation: field luôn private, chỉ truy cập qua property có kiểm soát


Đã triển khai


Student.cs: class chứa thuộc tính Id, Name, Age, Class, Score, tất cả field private, expose qua property có validate:

Age phải > 0
Score phải trong khoảng 0–10



StudentService.cs: tách riêng, chỉ chứa CRUD thuần túy (AddStudent, RemoveStudent, GetAllStudents), không xử lý nhập liệu/in ấn — tránh gộp logic I/O vào Service.
Bai2.cs: chứa toàn bộ phần nhập liệu từ Console (NhapSinhVien(), InDanhSach()) và menu điều phối gọi StudentService.




Ngày 2 — Interface, Inheritance, Abstraction, Polymorphism

Nội dung đã học


Inheritance: class con kế thừa field/method từ class cha qua : Base, dùng virtual/override để ghi đè hành vi, gọi base(...) để tái sử dụng constructor/method cha.
Abstraction: abstract class không thể khởi tạo trực tiếp, buộc class con phải implement đầy đủ method abstract; có thể chứa cả method thường dùng chung.
Interface: định nghĩa "hợp đồng" (method cần có), không quan tâm cách implement; một class có thể implement nhiều interface (khác với chỉ kế thừa được 1 class).
Polymorphism: cùng một lời gọi method nhưng chạy ra hành vi khác nhau tùy loại object thực tế tại runtime.


Đã triển khai


IStudentService / ICrudService<T>: interface generic định nghĩa CRUD chuẩn hóa (Add, Remove, GetAll), cho StudentService implement.
Person → Student, Person → Teacher: minh họa kế thừa cơ bản, override ShowInfo().
Shape (abstract) → Circle, Rectangle, Triangle: minh họa abstraction, mỗi hình tự implement CalculateArea()/CalculatePerimeter().
Employee (abstract) → FullTimeEmployee, PartTimeEmployee, Manager (kế thừa 2 tầng): minh họa cả abstraction + inheritance + polymorphism trong bài tổng hợp.
IPayable, IReportable: minh họa 1 class implement nhiều interface cùng lúc.
EmployeeService: loop qua List<Employee> và gọi GetReport()/CalculateSalary() — thể hiện rõ polymorphism khi mỗi loại nhân viên tự tính lương khác nhau dù code gọi giống hệt nhau.




Cấu trúc project 

tuan2/
├── Abstraction/
│   ├── Shape.cs
│   ├── Circle.cs
│   ├── Rectangle.cs
│   ├── Employee.cs
│   ├── FullTimeEmployee.cs
│   └── Intern.cs
├── Inheritance/
│   ├── Person.cs
│   ├── Student.cs
│   ├── Teacher.cs
│   └── PartTimeTeacher.cs
├── Interface/
│   ├── IPayable.cs
│   ├── ICrudService.cs
│   └── Interface_service/
├── polymorphism/
│   └── Polymorphism.cs
├── bai1.cs
├── bai2.cs
├── Program.cs
└── StudentService.cs