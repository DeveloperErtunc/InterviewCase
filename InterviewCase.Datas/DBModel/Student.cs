namespace InterviewCase.Datas.DBModel;
public class Student
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public int DepartMentId { get; set; }
    public Department? Department { get; set; }
}
