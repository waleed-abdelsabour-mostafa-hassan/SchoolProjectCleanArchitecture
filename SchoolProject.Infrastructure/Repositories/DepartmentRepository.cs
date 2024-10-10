using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBasics;

namespace SchoolProject.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {

        #region Fields
        private DbSet<Department> departments;
        #endregion

        #region Constructors
        public DepartmentRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            departments = dBContext.Set<Department>();
        }
        #endregion

        #region Helper Functions

        #endregion
    }
}
