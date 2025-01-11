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
    public class UserRepository : IRepository<User>
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) 
            => _context = context;

        public async Task<User> GetById(int id)
            => await  _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        
        public async Task<IEnumerable<User>> GetAll()
            => await _context.Users.ToListAsync();
        

        public async Task Add(User entity)
        {
            _context.Users.Add(entity);
           await _context.SaveChangesAsync();
        }

        public async Task Update(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User entity)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
