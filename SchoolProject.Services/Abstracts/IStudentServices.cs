using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Services.Abstracts
{
    public interface IStudentServices
    {
        public Task<List<Student>> GetStudentsListAsync();
        public Task<Student> GetStudentByIdWithIncludeAsync(int id);
        public Task<Student> GetByIdAsync(int id);
        public Task<string> AddAsync(Student student);
        public Task<string> EditAsync(Student student);
        public Task<string> DeleteAsync(Student student);
        // check name exists when add student
        public Task<bool> IsNameArExists(string nameAr);
        public Task<bool> IsNameEnExists(string nameEn);
        // check name exists when edit student
        public Task<bool> IsNameArExistsExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExistsExcludeSelf(string nameEn, int id);
        public IQueryable<Student> GetStudentsListQueryable();
        public IQueryable<Student> GetStudentsListByDepartmentIdQueryable(int deptId);
        public IQueryable<Student> FilterStudentsPaginatedQueryable(StudentOrderingEnum orderingEnum, string searchAr, string searchEn);
    }
}
