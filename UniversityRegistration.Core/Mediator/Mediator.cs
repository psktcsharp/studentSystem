using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistration.Core.Interfaces;
using UniversityRegistration.Core.Mediator.Commands;
using UniversityRegistration.Core.Mediator.Handlers;
using UniversityRegistration.Core.Mediator.Queries;

namespace UniversityRegistration.Core.Mediator
{
    public class Mediator : IMediator
    {
        private readonly IUnitOfWork _unitOfWork;

        public Mediator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            return request switch
            {
                RegisterCourseCommand command => await HandleCommand<TResponse>(command),
                GetStudentCoursesQuery query => await HandleQuery<TResponse>(query),
                _ => throw new ArgumentException("Invalid request type")
            };
        }
        private async Task<TResponse> HandleCommand<TResponse>(RegisterCourseCommand command)
        {
            var handler = new RegisterCourseCommandHandler(_unitOfWork);
            return (TResponse)(object)await handler.Handle(command);
        }
        private async Task<TResponse> HandleQuery<TResponse>(GetStudentCoursesQuery query)
        {
            var handler = new GetStudentCoursesQueryHandler(_unitOfWork);
            return (TResponse)(object)await handler.Handle(query);
        }
    }
}
