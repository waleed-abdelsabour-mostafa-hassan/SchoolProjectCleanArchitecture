using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.API.Controllers
{
    [ApiController]
    public class StudentController : AppControllerBase
    {


        #region Handle Functions

        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetAllStudents()
        {
            var response = await Mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }
        [HttpGet(Router.StudentRouting.PaginatedList)]
        public async Task<IActionResult> GetPaginatedList([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(response);
        }

        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddStudentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut(Router.StudentRouting.Edit)]
        public async Task<IActionResult> Update([FromBody] EditStudentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteStudentCommand(id));
            return NewResult(response);
        }
        #endregion
    }
}
