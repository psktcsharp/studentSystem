using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistration.Core.Entities;

namespace UniversityRegistration.Core.Interfaces
{
    public interface ICollegeRepository
    {
        College GetById(Guid id);
        IEnumerable<College> GetAll();
        void Add(College college);
        void Update(College college);
        void Delete(Guid id);
    }
}