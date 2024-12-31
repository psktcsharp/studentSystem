using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistration.Core.Entities;
using UniversityRegistration.Core.Interfaces;

namespace UniversityRegistration.Core.Implementations
{
    public class InMemoryCollegeRepository : ICollegeRepository
    {
        private readonly List<College> _colleges = new List<College>();

        public College GetById(Guid id)
        {
            return _colleges.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<College> GetAll()
        {
            return _colleges;
        }

        public void Add(College college)
        {
            _colleges.Add(college);
        }
        public void Update(College college)
        {
            var existingCollege = _colleges.FirstOrDefault(c => c.Id == college.Id);
            if (existingCollege != null)
            {
                existingCollege.UpdateInfo(college.Name);
            }
        }

        public void Delete(Guid id)
        {
            var collegeToRemove = _colleges.FirstOrDefault(c => c.Id == id);
            if (collegeToRemove != null)
            {
                _colleges.Remove(collegeToRemove);
            }
        }
    }
}