using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBlog.Domain.Data;
using AppBlog.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace AppBlog.Domain.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
            => _context = context;

        public async Task<Category> GetById(int id)
            => await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Category>> GetAll()
            => await _context.Categories
                .Include(p => p.Posts)
                .ToListAsync();

        public async Task Add(Category entity)
        {
            _context.Categories.Add(entity);
            await _context.SaveChangesAsync();

        }

        public async Task Update(Category entity)
        {
            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Category entity)
        {
            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
