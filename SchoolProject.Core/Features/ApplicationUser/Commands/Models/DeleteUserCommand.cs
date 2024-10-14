﻿using MediatR;
using SchoolProject.Core.Basics;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Models
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }

        public DeleteUserCommand(string id)
        {
            Id = id;
        }
    }
}
