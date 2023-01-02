Console.WriteLine("Hello, World!");
var servics = Injections.ConfigurationService();
var studentService = servics.GetRequiredService<IStudenService>();
var departmentService = servics.GetRequiredService<IDepartmentService>();
var data = await departmentService.Create(new DepartmentCreateDTO { Name = "Elektirik" });
var data2 = await departmentService.Create(new DepartmentCreateDTO { Name = "Pazarlama" });
WriteDepartment(data);
WriteDepartment(data2);
Console.ReadLine();
void WriteDepartment(string data)
{
    var department =  JsonConvert.DeserializeObject<ResponseModel<Department>>(data);
    if(department.IsSucess)
    {
        Console.WriteLine("Department Added"+ JsonConvert.SerializeObject(department.Data));
    }
}