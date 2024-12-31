using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistration.Core.Entities;

namespace UniversityRegistration.Core.Interfaces
{
    public interface IRegistrationRepository
    {
        Registration GetById(Guid id);
        IEnumerable<Registration> GetAll();
        void Add(Registration registration);
        void Update(Registration registration);
        void Delete(Guid id);
    }
}