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
        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
{
    // check if user exist
    var oldUser = await _userManager.FindByIdAsync(request.Id);
    // not found
    if (oldUser == null) { return NotFound<string>(_localizer[SharedResourcesKeys.NotFound]); }
    // mapping
    var newUser = _mapper.Map(request, oldUser);
    // update
    var UpdateUser = await _userManager.UpdateAsync(newUser);
    //result is success
    if (!UpdateUser.Succeeded)
    {
        return BadRequest<string>(_localizer[SharedResourcesKeys.UpdateFailed]);
    }
    return Success<string>(_localizer[SharedResourcesKeys.Updated]);

}

public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
{
    //Check If User Is Exists
    var user = await _userManager.FindByIdAsync(request.Id);
    //If Not Exist Not found
    if (user == null) return NotFound<string>(_localizer[SharedResourcesKeys.NotFound]);
    //Delete The User
    var result = await _userManager.DeleteAsync(user);
    // In Case Of Failure
    if (!result.Succeeded) return BadRequest<string>(_localizer[SharedResourcesKeys.DeletedFailed]);

    return Deleted<string>(_localizer[SharedResourcesKeys.Deleted]);
}
        #endregion
    }
}
