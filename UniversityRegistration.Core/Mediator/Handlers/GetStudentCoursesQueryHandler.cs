using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using UniversityRegistration.Core.Entities;
using UniversityRegistration.Core.Interfaces;
using UniversityRegistration.Core.Mediator.Handlers;
using UniversityRegistration.Core.Mediator.Queries;

namespace UniversityRegistration.Core.Mediator.Handlers
{
    public class GetStudentCoursesQueryHandler : IHandler<GetStudentCoursesQuery, IEnumerable<Course>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetStudentCoursesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Course>> Handle(GetStudentCoursesQuery request)
        {
            var registrations = _unitOfWork.RegistrationRepository.GetAll()
                  .Where(r => r.Student.Id == request.StudentId);
            var courses = registrations.Select(r => r.Course);
            return courses;
        }
    }
}