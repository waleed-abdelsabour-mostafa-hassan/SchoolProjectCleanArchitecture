using SchoolProject.Data.Entities;

namespace SchoolProject.Services.Abstracts
{
    public interface IDepartmentServices
    {
        public Task<Department> GetDepartmentByIdAsync(int id);
        public Task<bool> IsDepartmentIdExists(int deptId);
    }
}
