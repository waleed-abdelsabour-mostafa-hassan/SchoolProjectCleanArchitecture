using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.InfrastructureBasics;

namespace SchoolProject.Infrastructure.Abstracts
{
    public interface IDepartmentRepository : IGenericRepositoryAsync<Department>
    {
    }
}
