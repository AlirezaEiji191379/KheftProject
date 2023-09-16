using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace KheftProject.Core.DataAccess.Repository.Abstraction;

public interface IBaseRepository<T>
{
    Task Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    IQueryable<T> GetAll(bool trackChanges);
}