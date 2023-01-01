namespace InterviewCase.Models.DTO;
public class StudentDetailDTO: StudentDTO
{
public DepartmentDTO Department { get; set; }
}

public class StudenCreateDTO
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string LastName { get; set; }
    public int? DepartmentId { get; set; }
}
public class StudentDTO : BaseDTO
{
    public string Code { get; set; }
    public string LastName { get; set; }
}