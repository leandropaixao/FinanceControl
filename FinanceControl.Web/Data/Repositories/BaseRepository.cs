using Microsoft.EntityFrameworkCore;

namespace FinanceControl.Web.Data.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task NewAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task EditAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified; 
        await SaveChangesAsync();
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity == null) return false;
        _context.Set<T>().Remove(entity);
        await SaveChangesAsync();
        return true;
    }

    public async Task<List<T>> SearchAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> SearchByIdAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}