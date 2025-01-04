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
    public class RegisterCourseCommandHandler : IHandler<RegisterCourseCommand, (bool isSuccess, string errorMessage)>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCourseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<(bool isSuccess, string errorMessage)> Handle(RegisterCourseCommand request)
        {
            var student = _unitOfWork.StudentRepository.GetById(request.StudentId);
            var course = _unitOfWork.CourseRepository.GetById(request.CourseId);

            if (student == null || course == null)
            {
                return (false, "Student or Course not found");
            }
            //Get college based on student or any other logic
            var college = _unitOfWork.CollegeRepository.GetAll().FirstOrDefault();
            if (college == null)
            {
                return (false, "College not found");
            }

            var ruleService = new CollegeRuleService();
            var (isValid, errorMessage) = await ruleService.Validate(student, course, college, _unitOfWork);
            if (!isValid)
            {
                return (false, errorMessage);
            }

            var registration = new Registration(student, course);
            _unitOfWork.RegistrationRepository.Add(registration);
            _unitOfWork.Save();

            return (true, string.Empty);
        }
    }
}