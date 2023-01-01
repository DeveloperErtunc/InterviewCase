namespace InterviewCase.Models.DBModel;
public class Student:BaseEntity
{
    public string Code { get; set; }
    public string LastName { get; set; }
    public int? DepartMentId { get; set; }
    public Department? Department { get; set; }
}
