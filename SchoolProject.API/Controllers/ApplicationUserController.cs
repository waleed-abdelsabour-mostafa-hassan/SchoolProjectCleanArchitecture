using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Features.ApplicationUser.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.API.Controllers
{
    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {
        [HttpPost(Router.ApplicationUserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut(Router.ApplicationUserRouting.Edit)]
        public async Task<IActionResult> Update([FromBody] EditUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.ApplicationUserRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var response = await Mediator.Send(new DeleteUserCommand(id));
            return NewResult(response);
        }

        [HttpGet(Router.ApplicationUserRouting.PaginatedList)]
        public async Task<IActionResult> GetPaginatedList([FromQuery] GetUserPaginationListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet(Router.ApplicationUserRouting.GetById)]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            //var response = await Mediator.Send(new GetUserByIdQuery() { Id==id}); // if dont use parametrized constructor 
            var response = await Mediator.Send(new GetUserByIdQuery(id));
            return NewResult(response);
        }
    }
}
