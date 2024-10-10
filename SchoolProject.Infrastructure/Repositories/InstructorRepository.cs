using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBasics;

namespace SchoolProject.Infrastructure.Repositories
{
    public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
    {
        #region Fields
        private DbSet<Instructor> instructors;
        #endregion

        #region Constructors
        public InstructorRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            instructors = dBContext.Set<Instructor>();
        }
        #endregion

        #region Helper Functions

        #endregion
    }
}
