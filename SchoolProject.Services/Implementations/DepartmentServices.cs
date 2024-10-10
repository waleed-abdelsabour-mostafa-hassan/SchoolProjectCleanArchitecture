using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Services.Abstracts;

namespace SchoolProject.Services.Implementations
{
    public class DepartmentServices : IDepartmentServices
    {
        #region Fields
        private readonly IDepartmentRepository _departmentRepository;
        #endregion

        #region Constructors
        public DepartmentServices(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        #endregion

        #region Module Functions
        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            //.Include(d => d.Students) //to use pagination
            var department = await _departmentRepository.GetTableNoTracking()
                                                  .Where(x => x.Id == id)
                                                  .Include(d => d.DepartmentSubjects)
                                                  .ThenInclude(ds => ds.Subject)
                                                  .Include(d => d.Instructors)
                                                  .Include(d => d.Instructor)
                                                  .FirstOrDefaultAsync();
            return department;
        }
        #endregion
    }
}
