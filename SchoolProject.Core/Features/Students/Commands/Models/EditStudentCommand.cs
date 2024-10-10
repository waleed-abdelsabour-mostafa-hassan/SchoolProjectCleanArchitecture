using MediatR;
using SchoolProject.Core.Basics;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class EditStudentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string AddressAr { get; set; }
        public string AddressEn { get; set; }
        public string Phone { get; set; }

        public int DepartmentId { get; set; }
    }
}
