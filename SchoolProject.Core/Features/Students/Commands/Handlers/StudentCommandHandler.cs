using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basics;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Services.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
                                         IRequestHandler<AddStudentCommand, Response<string>>,
                                         IRequestHandler<EditStudentCommand, Response<string>>,
                                         IRequestHandler<DeleteStudentCommand, Response<string>>

    {

        #region Fields
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion
        #region Constructors
        public StudentCommandHandler(IStudentServices studentServices,
                                     IMapper mapper,
                                     IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _studentServices = studentServices;
            _mapper = mapper;
            _localizer = localizer;
        }

        #endregion
        #region Handle functions
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            // mapping between request and student
            var studentmapping = _mapper.Map<Student>(request);
            // Add
            var result = await _studentServices.AddAsync(studentmapping);
            // return response
            if (result == "Success")
            {
                return Created("");
            }
            else
            {
                return BadRequest<string>();
            }
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            // check if id is Exist or not
            var student = _studentServices.GetByIdAsync(request.Id);
            // return notfound
            if (student == null) return NotFound<string>();
            // mapping between request and student
            var studentMapper = _mapper.Map<Student>(request);
            //var studentMapper = await _mapper.Map(request, student);
            // Call service that make Edit
            var result = await _studentServices.EditAsync(studentMapper);
            // return response
            if (result == "Success")
            {
                return Success((string)_localizer[SharedResourcesKeys.Success]);
                //return Success<string>(_localizer[SharedResourcesKeys.Updated]);
            }
            else
            {
                return BadRequest<string>();
            }
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            // check if id is Exist or not
            var student = await _studentServices.GetByIdAsync(request.Id);
            // return notfound
            if (student == null) return NotFound<string>();
            // Call service that make Delete
            var result = await _studentServices.DeleteAsync(student);
            //return response
            if (result == "Success")
            {
                //return Deleted<string>($"Deleted Successfully Of Student ID {request.Id}");
                return Deleted<string>(_localizer[SharedResourcesKeys.Deleted]);
            }
            else
            {
                return BadRequest<string>();
            }
        }
        #endregion
    }
}
