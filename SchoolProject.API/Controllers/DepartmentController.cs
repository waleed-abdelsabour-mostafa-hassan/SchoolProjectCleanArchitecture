using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Department.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.API.Controllers
{

    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        #region Handle Functions
        //[HttpGet(Router.DepartmentRouting.GetById)]
        //public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
        //{
        //    var response = await Mediator.Send(new GetDepartmentByIdQuery(id));
        //    return NewResult(response);
        //}

        // send object to use pagination
        [HttpGet(Router.DepartmentRouting.GetById)]
        public async Task<IActionResult> GetDepartmentById([FromQuery] GetDepartmentByIdQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
        #endregion
    }
}
