using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Data;
using dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet.Repository.Courses
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly DataContext _context;
        public CoursesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetOne(int id)
        {
            return await _context.Courses.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public void Add(Course course)
        {
            _context.Add(course);
        }

        public void Delete(Course course)
        {
            _context.Courses.Remove(course);
        }

        public void Update(Course course)
        {
            _context.Update(course);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}