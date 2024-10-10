using AutoMapper;

namespace SchoolProject.Core.Mapping.MappingDepartment
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetDepartmentByIdMapping();
        }
    }
}
