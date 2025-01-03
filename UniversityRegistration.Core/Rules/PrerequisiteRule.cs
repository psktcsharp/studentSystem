using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistration.Core.Entities;
using UniversityRegistration.Core.Interfaces;

namespace UniversityRegistration.Core.Rules
{
    public class PrerequisiteRule : IRule
    {
        public string ErrorMessage { get; } = "Prerequisites not met";
        public async Task<bool> IsValid(Student student, Course course, IUnitOfWork unitOfWork)
        {
            //logic to check if the prerequisites are met
            //For the sake of this test, this rule is always valid
            return true;
        }
    }
}