using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistration.Core.Entities;
using UniversityRegistration.Core.Interfaces;
using UniversityRegistration.Core.Mediator;
using UniversityRegistration.Core.Mediator.Commands;

namespace UniversityRegistration.Core.Mediator.Handlers
{
    public class RegisterCourseCommandHandler : IHandler<RegisterCourseCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCourseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(RegisterCourseCommand request)
        {
            var student = _unitOfWork.StudentRepository.GetById(request.StudentId);
            var course = _unitOfWork.CourseRepository.GetById(request.CourseId);

            if (student == null || course == null)
            {
                return false; // or throw an exception
            }

            var registration = new Registration(student, course);
            _unitOfWork.RegistrationRepository.Add(registration);
            _unitOfWork.Save();

            return true;
        }
    }
    public interface IHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}