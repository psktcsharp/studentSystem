using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistration.Core.Entities;
using UniversityRegistration.Core.Interfaces;

namespace UniversityRegistration.Core.Implementations
{
    public class InMemoryRegistrationRepository : IRegistrationRepository
    {
        private readonly List<Registration> _registrations = new List<Registration>();

        public Registration GetById(Guid id)
        {
            return _registrations.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Registration> GetAll()
        {
            return _registrations;
        }

        public void Add(Registration registration)
        {
            _registrations.Add(registration);
        }
        public void Update(Registration registration)
        {
            var existingRegistration = _registrations.FirstOrDefault(r => r.Id == registration.Id);
            if (existingRegistration != null)
            {
                existingRegistration.UpdateInfo(registration.Student, registration.Course);
            }
        }

        public void Delete(Guid id)
        {
            var registrationToRemove = _registrations.FirstOrDefault(r => r.Id == id);
            if (registrationToRemove != null)
            {
                _registrations.Remove(registrationToRemove);
            }
        }
    }
}