namespace InterviewCase.Services.Services;

public class DepartmentService:BaseService<Department>, IDepartmentService
{
    IMapper _mapper;
    public DepartmentService(IMapper mapper, InterviewContext db) :base(db)
    {
        _mapper = mapper;
    }

    public async Task<string> GetDepartments()
    {
        var datas = await GetIQueryable().ToListAsync();
        return ToJson(ResponseModel<List<DepartmentDetailDTO>>.GetSucess(_mapper.Map<List<DepartmentDetailDTO>>(datas)));
    }

    public async Task<string> Create(DepartmentCreateDTO model)
    {
        var department = _mapper.Map<Department>(model);
        return ToJson(await Create(department));
    }

    private string ToJson<T>(T data) where T : class
    {
        return JsonConvert.SerializeObject(data);
    }
}
