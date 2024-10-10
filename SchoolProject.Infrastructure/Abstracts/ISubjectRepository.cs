using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.InfrastructureBasics;

namespace SchoolProject.Infrastructure.Abstracts
{
    public interface ISubjectRepository : IGenericRepositoryAsync<Subject>
    {
    }
}
