Console.WriteLine("Hello, World!");
var servics = Injections.ConfigurationService();
var studentService = servics.GetRequiredService<IStudenService>();
var departmentService = servics.GetRequiredService<IDepartmentService>(); ;
Console.WriteLine( await studentService.Create(new StudenCreateDTO  { Code = "12312321", LastName = "Akça", Name = "Ertunç" }));
Console.ReadLine();