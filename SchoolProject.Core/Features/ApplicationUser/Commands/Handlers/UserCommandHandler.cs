using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basics;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
                                    IRequestHandler<AddUserCommand, Response<string>>,
                                    IRequestHandler<EditUserCommand, Response<string>>,
                                    IRequestHandler<DeleteUserCommand, Response<string>>
    {

        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly UserManager<User> _userManager;
        #endregion

        #region Constructors
        public UserCommandHandler(IMapper mapper,
                                  UserManager<User> userManager,
                                  IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _mapper = mapper;
            _localizer = localizer;
            _userManager = userManager;
        }


        #endregion

        #region Handle functions
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            // if Email is exists
            var userEmail = await _userManager.FindByEmailAsync(request.Email);
            // email exists
            if (userEmail != null)
            {
                return BadRequest<string>(_localizer[SharedResourcesKeys.EmailIsExist]);
            }

            // if Username is exists
            var username = await _userManager.FindByNameAsync(request.UserName);
            // username exists
            if (username != null)
            {
                return BadRequest<string>(_localizer[SharedResourcesKeys.UserNameIsExist]);
            }
            //mapping
            var identityUser = _mapper.Map<User>(request);
            //create
            var createUser = await _userManager.CreateAsync(identityUser, request.Password);
            //failed
            if (!createUser.Succeeded)
            {
                return BadRequest<string>(createUser.Errors.FirstOrDefault().Description);
            }
            // message

            //success
            return Created("");


        }
        #endregion
    }
}
