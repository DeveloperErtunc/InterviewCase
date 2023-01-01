namespace InterviewCase.Models.DTO;
public class DepartmentDTO : BaseDTO
{
}
public class DepartmentCreateDTO 
{
    public string Name { get; set; }
}

public class DepartmentDetailDTO: DepartmentDTO
{
    public List<StudentDTO>? Students { get; set; }

}