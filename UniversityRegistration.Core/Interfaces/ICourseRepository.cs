using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistration.Core.Entities;

namespace UniversityRegistration.Core.Interfaces
{
    public interface ICourseRepository
    {
        Course GetById(Guid id);
        IEnumerable<Course> GetAll();
        void Add(Course course);
        void Update(Course course);
        void Delete(Guid id);
    }
}
