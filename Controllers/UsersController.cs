using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Models;
using dotnet.Models.DTOs;
using dotnet.Repository.Users;
using dotnet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _repository;

        public UsersController(IUsersRepository usersRepository)
        {
            _repository = usersRepository;
        }

        #region CRUD
        [HttpGet]
        [Authorize(Roles = "manager, employee")]
        public async Task<IActionResult> Get()
        {
            var users = await _repository.GetAll();

            return users.Any()
                        ? Ok(users)
                        : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await _repository.GetById(id);

            return user != null ? Ok(user) : NotFound("User not found");
        }

        [HttpPost]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> Post(User usuario)
        {

            // TODO: Crypto password

            _repository.Add(usuario);

            return await _repository.SaveChangesAsync()
                    ? Ok("Usuário adicionado com sucesso")
                    : BadRequest("Erro ao salvar usuário");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] User usuario)
        {
            var user = await _repository.GetById(id);

            if (user == null) return NotFound();

            user.Nome = usuario.Nome ?? user.Nome;
            user.DataNascimento = usuario.DataNascimento != new DateTime()
                ? usuario.DataNascimento : user.DataNascimento;

            _repository.Update(user);

            return await _repository.SaveChangesAsync()
                    ? Ok("Usuário salvo com sucesso")
                    : BadRequest("Erro ao salvar usuário");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var user = await _repository.GetById(id);

            if (user == null) return NotFound();

            _repository.Delete(user);

            return await _repository.SaveChangesAsync()
                    ? Ok("Usuário removido com sucesso")
                    : BadRequest("Erro ao remover usuário");
        }

        #endregion
        #region Auth
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO dto)
        {
            var userExists = await _repository.GetByLogin(dto);

            // TODO: Compare crypto password

            if (userExists == null) return NotFound(new
            {
                message = "User or password invalid"
            });

            var token = TokenService.GenerateToken(userExists);

            userExists.Password = "";

            return Ok(new
            {
                user = userExists,
                token
            });

        }
        #endregion
    }
}