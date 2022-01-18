using Domain.ToDos;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
namespace Infra.Repositories
{
    public class CategoryDAL : IDAL<Category>
    {
        private readonly AppDbContext _context;
        public CategoryDAL(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<Category?> GetAsync(Guid id)
        {
            return await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<bool> InsertAsync(Category entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Remove(Category entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateAsync(Category entity)
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
