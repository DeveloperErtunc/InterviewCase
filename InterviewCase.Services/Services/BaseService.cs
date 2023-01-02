using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InterviewCase.Services.Services;
public class BaseService<T> : IBaseService<T> where T : class
{

    InterviewContext _db;

    public BaseService(InterviewContext db)
    {
        _db = db;
    }

    public async Task<ResponseModel<T>> Create(T model)
    {
        try
        {
            await _db.Set<T>().AddAsync(model);
            await SaveChanges();
            return ResponseModel<T>.GetSucess(model);
        }
        catch (Exception ex)
        {

            return ResponseModel<T>.GetFailed(ex.Message);
        }
  
    }

    public async Task<List<T>> GetList()
    {
        return await _db.Set<T>().ToListAsync();
    }
    public IQueryable<T> GetIQueryable()
    {
        return _db.Set<T>();
    }
    public async Task SaveChanges()
    {
        await _db.SaveChangesAsync();
    }

    public async Task<T?> GetFirstOrDefault(Expression<Func<T, bool>> predicate)
    {
        return await _db.Set<T>().FirstOrDefaultAsync(predicate);
    }
}
