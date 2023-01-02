namespace InterviewCase.Services.IServices;

public interface IDepartmentService : IBaseService<Department>
{
    Task<string> GetDepartments();
    Task<string> Create(DepartmentCreateDTO model);
}
