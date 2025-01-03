using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityRegistration.Core.Entities;
using UniversityRegistration.Core.Interfaces;
using UniversityRegistration.Core.Rules;

namespace UniversityRegistration.Core.Implementations
{
    public class CollegeRuleService
    {
        public async Task<(bool isValid, string errorMessage)> Validate(Student student, Course course, College college, IUnitOfWork unitOfWork)
        {
            if (college == null)
            {
                return (false, "College not found");
            }
            var errors = new List<string>();
            foreach (var rule in college.Rules)
            {
                var isValid = await rule.IsValid(student, course, unitOfWork);
                if (!isValid)
                {
                    errors.Add(rule.ErrorMessage);
                }
            }
            return (!errors.Any(), string.Join("\n", errors));
        }
    }
}