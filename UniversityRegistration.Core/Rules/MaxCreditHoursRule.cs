using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistration.Core.Entities;
using UniversityRegistration.Core.Interfaces;

namespace UniversityRegistration.Core.Rules
{
    public class MaxCreditHoursRule : IRule
    {
        public string ErrorMessage { get; } = "Maximum credit hours exceeded.";
        private const int MaxCreditHours = 18;
        public async Task<bool> IsValid(Student student, Course course, IUnitOfWork unitOfWork)
        {
            var registeredCourses = unitOfWork.RegistrationRepository.GetAll()
                   .Where(r => r.Student.Id == student.Id)
                  .Select(r => r.Course);
            int totalCredits = registeredCourses.Sum(c => c.CreditHours);
            return totalCredits + course.CreditHours <= MaxCreditHours;
        }
    }
}