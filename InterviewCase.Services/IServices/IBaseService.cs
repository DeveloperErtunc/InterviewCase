using System.Linq.Expressions;

namespace InterviewCase.Services.IServices;
public interface IBaseService<T> where T : class
{
    Task<ResponseModel<T>> Create(T model);
     Task<List<T>> GetList();
    Task<T?> GetFirstOrDefault(Expression<Func<T, bool>> predicate);
    Task SaveChanges();
    IQueryable<T> GetIQueryable();
}
