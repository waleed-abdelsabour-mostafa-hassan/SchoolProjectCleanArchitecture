using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBasics;

namespace SchoolProject.Infrastructure.Repositories
{
    public class SubjectRepository : GenericRepositoryAsync<Subject>, ISubjectRepository
    {
        #region Fields
        private DbSet<Subject> subjects;
        #endregion

        #region Constructors
        public SubjectRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            subjects = dBContext.Set<Subject>();
        }
        #endregion

        #region Helper Functions

        #endregion
    }
}
