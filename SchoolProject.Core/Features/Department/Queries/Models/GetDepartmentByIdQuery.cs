using MediatR;
using SchoolProject.Core.Basics;
using SchoolProject.Core.Features.Department.Queries.Results;

namespace SchoolProject.Core.Features.Department.Queries.Models
{
    public class GetDepartmentByIdQuery : IRequest<Response<GetSingleDepartmentResponse>>
    {
        public int Id { get; set; }
        public int StudentPageNumber { get; set; }   // for pagination
        public int StudentPageSize { get; set; }     // for pagination
        /*public GetDepartmentByIdQuery(int id)
        {
            Id = id;
        }*/
    }
}
