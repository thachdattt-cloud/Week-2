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
###
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

###
---

## Ngày 3 — LINQ

### Nội dung đã học
Lambda expression: viết hàm không tên bằng `=>`, dùng với các delegate có sẵn (`Func`, `Action`, `Predicate`). LINQ Where: lọc dữ liệu theo điều kiện, trả về `IEnumerable<T>` (lazy evaluation). Select: biến đổi dữ liệu, có thể lấy 1 field hoặc tạo object ẩn danh. OrderBy/OrderByDescending/ThenBy: sắp xếp theo 1 hoặc nhiều tiêu chí. GroupBy: nhóm phần tử theo key, mỗi nhóm có `Key` và các phần tử con truy cập được qua vòng lặp. Kết hợp GroupBy với các hàm thống kê (`Average`, `Max`/`MaxBy`, `Count`) để tính toán riêng cho từng nhóm.

### Đã triển khai
`Student.cs`: entity chứa thông tin sinh viên (Id, Name, Age, Class, Score, Gender). `LambdaDemo.cs`: minh họa cách viết Lambda với `Func` và `Predicate`, tách riêng khỏi entity `Student` để không lẫn logic demo vào class dữ liệu. `StudentService.cs`: chứa toàn bộ các thao tác LINQ, gồm `FilterByAge()`/`FilterByClass()` (Where), `ShowStudentNames()` (Select), `ShowNamesOfStudentsOverAge()` (Where + Select), `ShowTop3Students()` (OrderByDescending + Take), `SortByClassAndScore()` (OrderBy + ThenBy), `GroupByClass()`/`GroupByScoreLevel()` (GroupBy), và `ShowClassStatistics()` (GroupBy + Average/MaxBy/Count) — tính điểm trung bình, sinh viên điểm cao nhất theo từng lớp. `ShowMenu()`: menu console điều phối gọi từng chức năng trên để test riêng lẻ.

### Ghi chú
Áp dụng naming convention nhất quán: PascalCase cho class/method (`StudentService`, `FilterByAge`), camelCase cho biến local (`studentsOverAge`, `choice`), tiền tố `_` cho field private (`_students`), tên method bắt đầu bằng động từ mô tả rõ hành động (`Show...`, `Filter...`, `Sort...`, `Group...`).

### Cấu trúc project (bổ sung)
```
tuan2/
├── LINQ/
│   ├── Student.cs
│   ├── LambdaDemo.cs
│   └── StudentService.cs
```

### Cách chạy Ngày 3
Gọi `new StudentService().ShowMenu();` từ `Program.cs`, chọn số tương ứng với chức năng muốn xem trong menu console.

Ngày 4 — Async/Await

Nội dung đã học

Vì sao cần bất đồng bộ: tránh chương trình bị "đứng" (block) khi chờ tác vụ chậm (gọi API, đọc file, query DB). Task/Task<T>: đại diện cho 1 công việc đang chạy, có thể chưa hoàn thành. async/await: async đánh dấu method bất đồng bộ, await chờ kết quả của 1 Task mà không block toàn bộ chương trình. Task.Delay dùng để mô phỏng độ trễ giống gọi DB/API thật. Task.WhenAll chạy nhiều task song song thay vì tuần tự, tiết kiệm thời gian. CancellationTokenSource/CancellationToken: cơ chế chuẩn để hủy một tác vụ đang chạy giữa chừng, dùng ThrowIfCancellationRequested() để kiểm tra và OperationCanceledException để bắt lỗi khi bị hủy.

Đã triển khai

Gio1Demo.cs: minh họa Task<T>, async/await cơ bản qua TinhBinhPhuongAsync() và ChaoAsync(), có ví dụ đối chiếu khi gọi async mà không await. Gio2Demo.cs: mô phỏng gọi DB qua LoadStudentsFromDbAsync()/LoadTeachersFromDbAsync(), minh họa chạy song song bằng Task.WhenAll và đo thời gian bằng Stopwatch. Gio3Demo.cs: minh họa CancellationToken qua DemLuiAsync(), tự động hủy sau 3 giây bằng CancelAfter(). StudentServiceAsync.cs + Gio4Menu.cs: bài tổng hợp — LoadStudentsAsync() có hỗ trợ CancellationToken, ráp vào menu console cho phép chọn load dữ liệu bình thường hoặc load có thể hủy giữa chừng, có xử lý try/catch đầy đủ.
tuan2/
├── asyn_task_await/
│   ├── cancellationToken.cs
│   ├── DemoApi.cs
│   ├── Test.cs
│   ├── Student.cs
│   ├── StudentServiceAsync.cs
│   └── Main.cs