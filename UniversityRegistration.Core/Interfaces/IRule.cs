using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistration.Core.Entities;

namespace UniversityRegistration.Core.Interfaces
{
    public interface IRule
    {
        public Task<bool> IsValid(Student student, Course course, IUnitOfWork unitOfWork);
        public string ErrorMessage { get; }
    }
}