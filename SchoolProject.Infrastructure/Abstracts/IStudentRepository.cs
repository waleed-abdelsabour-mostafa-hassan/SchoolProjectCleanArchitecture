using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.InfrastructureBasics;

namespace SchoolProject.Infrastructure.Abstracts
{
    public interface IStudentRepository : IGenericRepositoryAsync<Student>
    {
        public Task<List<Student>> GetStudentsListAsync();
    }
}
