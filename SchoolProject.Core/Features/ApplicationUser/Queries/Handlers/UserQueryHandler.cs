using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basics;
using SchoolProject.Core.Features.ApplicationUser.Queries.Models;
using SchoolProject.Core.Features.ApplicationUser.Queries.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Features.ApplicationUser.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler,
                                    IRequestHandler<GetUserPaginationListQuery, PaginatedResult<GetUserPaginationListResponse>>,
                                    IRequestHandler<GetUserByIdQuery, Response<GetSingleUserResponse>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly UserManager<User> _userManager;
        #endregion
        #region Constructors

        public UserQueryHandler(IMapper mapper,
                                UserManager<User> userManager,
                                IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _mapper = mapper;
            _localizer = localizer;
            _userManager = userManager;
        }

        #endregion
        #region Handle Functions
        public async Task<PaginatedResult<GetUserPaginationListResponse>> Handle(GetUserPaginationListQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();
            var paginatedList = await _mapper.ProjectTo<GetUserPaginationListResponse>(users).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;

        }

        public async Task<Response<GetSingleUserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            //var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == request.Id);
            var user = await _userManager.FindByIdAsync(request.Id);

            if (user == null)
            {
                return NotFound<GetSingleUserResponse>(_localizer[SharedResourcesKeys.NotFound]);
            }
            else
            {
                var result = _mapper.Map<GetSingleUserResponse>(user);
                return Success(result);
            }
        }
        #endregion
    }
}
