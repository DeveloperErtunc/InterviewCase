namespace InterviewCase.Models.DBModel;
public class Department:BaseEntity
{
    public List<Student>? Students { get; set; }
}
