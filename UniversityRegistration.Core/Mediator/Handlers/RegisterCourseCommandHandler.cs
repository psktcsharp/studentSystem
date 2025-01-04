using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistration.Core.Entities;
using UniversityRegistration.Core.Interfaces;
using UniversityRegistration.Core.Mediator;
using UniversityRegistration.Core.Mediator.Commands;
using UniversityRegistration.Core.Implementations;
using UniversityRegistration.Core.Rules;
using System.Linq;

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
                return false;
            }
            //Get college based on student or any other logic
            var college = _unitOfWork.CollegeRepository.GetAll().FirstOrDefault();
            if (college == null)
            {
                return false;
            }

            var ruleService = new CollegeRuleService();
            var (isValid, errorMessage) = await ruleService.Validate(student, course, college, _unitOfWork);
            if (!isValid)
            {
                System.Console.WriteLine(errorMessage);
                return false;
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