using dotnet.Data;
using dotnet.Models;
using dotnet.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace dotnet.Repository.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _context;
        public UsersRepository(DataContext context)
        {
            _context = context;
        }

        public Task<User?> GetByLogin(UserLoginDTO dto)
        {
            return _context.Users.Where(x => x.Nome == dto.Name &&
                                            x.Password == dto.Password)
                                .FirstOrDefaultAsync();
        }


        #region CRUD

        public async Task<User> GetById(int id)
        {
            return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public void Add(User Users)
        {
            _context.Add(Users);
        }

        public void Update(User Users)
        {
            _context.Update(Users);
        }

        public void Delete(User Users)
        {
            _context.Remove(Users);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        #endregion
    }
}