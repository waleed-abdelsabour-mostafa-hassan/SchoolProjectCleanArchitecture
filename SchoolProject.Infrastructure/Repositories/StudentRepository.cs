using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBasics;

namespace SchoolProject.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        #region Fields
        private readonly DbSet<Student> _students;
        #endregion

        #region Constructors
        public StudentRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _students = dBContext.Set<Student>();
        }
        #endregion

        #region Handles Functions
        public async Task<List<Student>> GetStudentsListAsync()
        {
            var students = await _students.Include(e => e.Department).ToListAsync();
            return students;
        }

        #endregion
    }
}
