using MediatR;
using SchoolProject.Core.Features.ApplicationUser.Queries.Results;
using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.ApplicationUser.Queries.Models
{
    public class GetUserPaginationListQuery : IRequest<PaginatedResult<GetUserPaginationListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
