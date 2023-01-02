namespace InterviewCase.Services.Services;
public class StudenService : BaseService<Student>,IStudenService
{
    IMapper _mapper;
    public StudenService(IMapper mapper, InterviewContext db) : base(db)
    {
        _mapper = mapper;
    }

    public async Task<string> GetStudens()
    {
        var data = await GetList();
        return ToJson(ResponseModel<List<StudentDTO>>.GetSucess(_mapper.Map<List<StudentDTO>>(data)));
    }

    public async Task<string> GetStudens(int id)
    {
        var student = await GetIQueryable().Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == id);
        if (student is not null)
            return ToJson(ResponseModel<StudentDetailDTO>.GetSucess(_mapper.Map<StudentDetailDTO>(student)));

        return ToJson(ResponseModel<StudentDetailDTO>.GetNotFound());
    }

    public async Task<string> Create(StudenCreateDTO model)
    {
        return ToJson(await Create(_mapper.Map<Student>(model)));
    }

    private string ToJson<T>(T data) where T : class
    {
        return JsonConvert.SerializeObject(data);
    }
}
