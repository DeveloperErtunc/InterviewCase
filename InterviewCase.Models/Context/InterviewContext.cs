namespace InterviewCase.Models.Context;
public class InterviewContext : DbContext
{
    public InterviewContext(DbContextOptions options) : base(options) => Database.EnsureCreated();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => base.OnConfiguring(optionsBuilder);
    public DbSet<Department> Departments { get; set; }
    public DbSet<Student> Students { get; set; }
}