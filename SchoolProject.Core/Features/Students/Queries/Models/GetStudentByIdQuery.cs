using MediatR;
using SchoolProject.Core.Basics;
using SchoolProject.Core.Features.Students.Queries.Results;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Response<GetSingleStudentResponse>>
    {
        public int Id { get; set; }
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
