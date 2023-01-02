Console.WriteLine("Hello, World!");
var servics = Injections.ConfigurationService();
var studentService = servics.GetRequiredService<IStudenService>();
var departmentService = servics.GetRequiredService<IDepartmentService>();

var data = await departmentService.Create(new DepartmentCreateDTO { Name = "Elektirik" });
var department = JsonConvert.DeserializeObject<ResponseModel<Department>>(data);
Write(department,"Departmend Added");
data = await departmentService.Create(new DepartmentCreateDTO { Name = "Pazarlama" });
var department2 = JsonConvert.DeserializeObject<ResponseModel<Department>>(data);
Write(department2, "Departmend Added");

if(department.IsSucess)
{
    data =await studentService.Create(new StudenCreateDTO { Code = "123456", DepartmentId = department.Data.Id, LastName = "Pehlivan", Name = "Sezer" });
    var student = JsonConvert.DeserializeObject<ResponseModel<Student>>(data);
    if(student.IsSucess)
    {
        Write(student, "Student Added");
    }
    data = await studentService.Create(new StudenCreateDTO { Code = "123456", DepartmentId = department2.Data.Id, LastName = "Pehlivan", Name = "Sezer" });
    student = JsonConvert.DeserializeObject<ResponseModel<Student>>(data);
    if (student.IsSucess)
    {
        Write(student, "Student Added");
    }
}

data = await departmentService.GetDepartments();
var departmentList = JsonConvert.DeserializeObject<ResponseModel<List<DepartmentDetailDTO>>>(data);
Write(departmentList,"Departmend List");

data = await studentService.GetStudens();
var studentList = JsonConvert.DeserializeObject<ResponseModel<List<StudentDTO>>>(data);
Write(studentList, "Student List");
Console.ReadLine();
void Write<T>(ResponseModel<T> data,string text) where T : class
{
    if(data.IsSucess)
    {
        Console.WriteLine(text + JsonConvert.SerializeObject(data.Data));
    }
}