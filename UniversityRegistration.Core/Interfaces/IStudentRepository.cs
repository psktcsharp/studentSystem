using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistration.Core.Entities;

namespace UniversityRegistration.Core.Interfaces
{
    public interface IStudentRepository
    {
        Student GetById(Guid id);
        IEnumerable<Student> GetAll();
        void Add(Student student);
        void Update(Student student);
        void Delete(Guid id);
    }
}