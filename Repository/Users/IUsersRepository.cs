using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Models;
using dotnet.Models.DTOs;

namespace dotnet.Repository.Users
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        void Add(User usuario);
        void Update(User usuario);
        void Delete(User id);
        Task<User?> GetByLogin(UserLoginDTO dto);

        Task<bool> SaveChangesAsync();
    }
}