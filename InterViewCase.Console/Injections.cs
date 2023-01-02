namespace InterviewCase.Console;
public class Injections
{
    public static IServiceProvider ConfigurationService()
    {
            return new ServiceCollection()
                .AddScoped(typeof(IStudenService), typeof(StudenService))
                  .AddScoped(typeof(IDepartmentService), typeof(DepartmentService))
                .AddDbContext<InterviewContext>(options => options.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Interviews;Integrated Security=True"))
                .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                .BuildServiceProvider();
    }
}
