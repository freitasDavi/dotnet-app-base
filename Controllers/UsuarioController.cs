
using dotnet.Models;
using dotnet.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _repository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _repository.BuscaUsuarios();

            return users.Any()
                        ? Ok(users)
                        : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await _repository.BuscaUsuario(id);

            return user != null ? Ok(user) : NotFound("User not found");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            _repository.AdicionaUsuario(usuario);

            return await _repository.SaveChangesAsync()
                    ? Ok("Usuário adicionado com sucesso")
                    : BadRequest("Erro ao salvar usuário");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] Usuario usuario)
        {
            var user = await _repository.BuscaUsuario(id);

            if (user == null) return NotFound();

            user.Nome = usuario.Nome ?? user.Nome;
            user.DataNascimento = usuario.DataNascimento != new DateTime()
                ? usuario.DataNascimento : user.DataNascimento;

            _repository.AtualizaUsuario(user);

            return await _repository.SaveChangesAsync()
                    ? Ok("Usuário salvo com sucesso")
                    : BadRequest("Erro ao salvar usuário");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var user = await _repository.BuscaUsuario(id);

            if (user == null) return NotFound();

            _repository.DeleteUsuario(user);

            return await _repository.SaveChangesAsync()
                    ? Ok("Usuário removido com sucesso")
                    : BadRequest("Erro ao remover usuário");
        }
    }
}