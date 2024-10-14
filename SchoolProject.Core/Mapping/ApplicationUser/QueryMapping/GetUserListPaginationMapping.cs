using SchoolProject.Core.Features.ApplicationUser.Queries.Results;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {

        public void GetUserListPaginationMapping()
        {
            CreateMap<User, GetUserPaginationListResponse>();
        }

    }
}
