using SchoolProject.Data.Entities;

namespace SchoolProject.Services.Abstracts
{
    public interface IDepartmentServices
    {
        public Task<Department> GetDepartmentByIdAsync(int id);
    }
}
