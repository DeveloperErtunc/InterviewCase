namespace InterviewCase.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    IBaseService<Student> _studensBaseService;
    IMapper _mapper;
    public StudentController(IBaseService<Student> studensBaseService, IMapper mapper)
    {
        _studensBaseService = studensBaseService;
        _mapper = mapper;
    }
    [HttpGet]
    [Route("Students")]
    public async Task<ResponseModel<List<StudentDTO>>> GetStudens()
    {
        var data = await _studensBaseService.GetList();
        return ResponseModel<List<StudentDTO>>.GetSucess(_mapper.Map<List<StudentDTO>>(data));
    }
    [HttpGet]
    [Route("Students/{id}")]
    public async Task<ResponseModel<StudentDetailDTO>> GetStudens(int id)
    {
        var student = await _studensBaseService.GetIQueryable().Include(x => x.Department).FirstOrDefaultAsync(x => x.Id ==id);
        if (student is not null)
            return ResponseModel<StudentDetailDTO>.GetSucess(_mapper.Map<StudentDetailDTO>(student));

        return ResponseModel<StudentDetailDTO>.GetNotFound();
    }

    [HttpPost]
    [Route("Create")]
    public async Task<ResponseModel<Student>> Create(StudenCreateDTO model)
    {
        return await _studensBaseService.Create(_mapper.Map<Student>(model));
    }
}