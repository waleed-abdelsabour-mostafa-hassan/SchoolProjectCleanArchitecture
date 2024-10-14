using MediatR;
using SchoolProject.Core.Basics;
using SchoolProject.Core.Features.ApplicationUser.Queries.Results;

namespace SchoolProject.Core.Features.ApplicationUser.Queries.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetSingleUserResponse>>
    {
        public string Id { get; set; }
        public GetUserByIdQuery(string id)
        {
            Id = id;
        }
    }
}
