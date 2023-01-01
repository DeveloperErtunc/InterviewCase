namespace InterviewCase.Services;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Student, StudentDetailDTO>();
        CreateMap<Student, StudentDTO>().ReverseMap();
        CreateMap<Student, StudenCreateDTO>().ReverseMap();

        CreateMap<Department, DepartmentCreateDTO>().ReverseMap();
        CreateMap<Department, DepartmentDetailDTO>().ReverseMap();
        CreateMap<Department, DepartmentDTO>().ReverseMap();
    }
}
