using ilya.Database;
using ilya.Filters.StudentFilters;
using ilya.Models;
using Microsoft.EntityFrameworkCore;

namespace ilya.Interfaces.StudentsInterfaces
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default);
    }

    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _dbContext;

        public StudentService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _dbContext.Set<Student>()
                .Where(w => w.Group.GroupName == filter.GroupName)
                .ToArrayAsync(cancellationToken);

            return students;
        }
    }
}
