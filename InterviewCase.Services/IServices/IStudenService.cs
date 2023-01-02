namespace InterviewCase.Services.IServices
{
    public interface IStudenService : IBaseService<Student>
    {
        Task<string> GetStudens();
        Task<string> GetStudens(int id);
        Task<string> Create(StudenCreateDTO model);
    }
}
