using dotnet.Models;

namespace dotnet.Repository.Courses
{
    public interface ICoursesRepository
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course> GetOne(int id);
        void Add(Course course);
        void Update(Course course);
        void Delete(Course id);
        Task<bool> SaveChangesAsync();
    }
}