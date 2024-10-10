using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basics;
using SchoolProject.Core.Features.Department.Queries.Models;
using SchoolProject.Core.Features.Department.Queries.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Services.Abstracts;
using System.Linq.Expressions;
using static SchoolProject.Core.Features.Department.Queries.Results.GetSingleDepartmentResponse;

namespace SchoolProject.Core.Features.Department.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler,
                                IRequestHandler<GetDepartmentByIdQuery, Response<GetSingleDepartmentResponse>>
    {
        #region Fields
        private readonly IDepartmentServices _departmentServices;
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion
        #region Constructors
        public DepartmentQueryHandler(IDepartmentServices departmentServices,
                                     IStudentServices studentServices,
                                     IMapper mapper,
                                     IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _departmentServices = departmentServices;
            _studentServices = studentServices;
            _mapper = mapper;
            _localizer = localizer;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<GetSingleDepartmentResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {

            // Get service by Id  include std sub inst
            var department = await _departmentServices.GetDepartmentByIdAsync(request.Id);
            // if id is not exist
            if (department == null) return NotFound<GetSingleDepartmentResponse>(_localizer[SharedResourcesKeys.NotFound]);
            //mapping
            var departmentMapper = _mapper.Map<GetSingleDepartmentResponse>(department);
            // pagination
            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.Id, e.Localize(e.NameAr, e.NameEn));
            var studentQuerable = _studentServices.GetStudentsListByDepartmentIdQueryable(request.Id);
            var PaginatedList = await studentQuerable.Select(expression).ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);
            departmentMapper.StudentList = PaginatedList;
            //return response
            return Success(departmentMapper);

        }
        #endregion
    }
}

