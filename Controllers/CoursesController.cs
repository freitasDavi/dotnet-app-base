using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Models;
using dotnet.Repository.Courses;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesRepository _repository;
        public CoursesController(ICoursesRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var courses = await _repository.GetAll();

            return courses.Any()
                        ? Ok(courses)
                        : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var course = await _repository.GetOne(id);

            return course != null
                        ? Ok(course)
                        : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Course course)
        {
            _repository.Add(course);

            return await _repository.SaveChangesAsync()
                    ? Ok("Curso adicionado com sucesso")
                    : BadRequest("Erro ao salvar curso");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] Course cour)
        {
            var course = await _repository.GetOne(id);

            if (course == null) return NotFound();

            course.Name = cour.Name ?? course.Name;
            course.Category = cour.Category ?? course.Category;

            _repository.Update(course);

            return await _repository.SaveChangesAsync()
                    ? Ok("Curso salvo com sucesso")
                    : BadRequest("Erro ao salvar Curso");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var course = await _repository.GetOne(id);

            if (course == null) return NotFound();

            _repository.Delete(course);

            return await _repository.SaveChangesAsync()
                    ? Ok("Curso removido com sucesso")
                    : BadRequest("Erro ao remover Curso");
        }
    }
}