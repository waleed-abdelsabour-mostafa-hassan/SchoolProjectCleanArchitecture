﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basics;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Services.Abstracts;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler,
                                IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
                                IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>,
                                IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
    {
        #region Fields
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion
        #region Constructors
        public StudentQueryHandler(IStudentServices studentServices,
                                   IMapper mapper,
                                   IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _studentServices = studentServices;
            _mapper = mapper;
            _localizer = localizer;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentServices.GetStudentsListAsync();
            var studentListResponse = _mapper.Map<List<GetStudentListResponse>>(studentList);
            var result = Success(studentListResponse);
            result.Meta = new { Count = studentListResponse.Count() };
            return result;
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentServices.GetStudentByIdWithIncludeAsync(request.Id);
            if (student == null)
            {
                return NotFound<GetSingleStudentResponse>(_localizer[SharedResourcesKeys.NotFound]);
            }
            else
            {
                var result = _mapper.Map<GetSingleStudentResponse>(student);
                return Success(result);
            }
        }

        public Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.Id, e.Localize(e.NameAr, e.NameEn), e.Localize(e.AddressAr, e.AddressEn), e.Phone, e.Localize(e.Department.NameAr, e.Department.NameEn));

            var filterQuerable = _studentServices.FilterStudentsPaginatedQueryable(request.OrderBy, request.SearchAr, request.SearchEn);
            var PaginatedList = filterQuerable.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return PaginatedList;
        }


        #endregion
    }
}
