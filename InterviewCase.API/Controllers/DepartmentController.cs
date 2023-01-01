namespace InterviewCase.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    IBaseService<Department> _departmentBaseService;
    IMapper _mapper;
    public DepartmentController(IBaseService<Department> departmentBaseService, IMapper mapper)
    {
        _departmentBaseService = departmentBaseService;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("Departments")]
    public async Task<ResponseModel<List<DepartmentDetailDTO>>> GetDepartments()
    {
        var datas = await _departmentBaseService.GetIQueryable().Include(x => x.Students).ToListAsync();
        return ResponseModel<List<DepartmentDetailDTO>>.GetSucess(_mapper.Map<List<DepartmentDetailDTO>>(datas));  
    }

    [HttpPost]
    [Route("Create")]
    public async Task<ResponseModel<Department>> Create(DepartmentCreateDTO model)
    {
        var department = _mapper.Map<Department>(model);
        return await _departmentBaseService.Create(department);
    }
}
