using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.MappingStudent
{
    public partial class StudentProfile
    {
        public void GetStudentListPaginationMapping()
        {
            CreateMap<Student, GetStudentPaginatedListResponse>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Localize(src.Department.NameAr, src.Department.NameEn)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Localize(src.AddressAr, src.AddressEn)))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone));
        }
    }
}
