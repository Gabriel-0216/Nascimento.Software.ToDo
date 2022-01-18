using Domain.ToDos;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class ToDoDAL : IDAL<ToDo>
    {
        private readonly AppDbContext _context;
        public ToDoDAL(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ToDo>> GetAllAsync()
        {
            return await _context.ToDos
                .Include(p => p.User)
                .Include(p => p.Category)
                .ToListAsync();
        }
        public async Task<ToDo?> GetAsync(Guid id)
        {
            return await _context.ToDos.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<bool> InsertAsync(ToDo entity)
        {
            _context.ToDos.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Remove(ToDo entity)
        {
            _context.ToDos.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateAsync(ToDo entity)
        {
            _context.ToDos.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
