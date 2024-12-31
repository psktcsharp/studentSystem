using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistration.Core.Entities;
using UniversityRegistration.Core.Interfaces;

namespace UniversityRegistration.Core.Implementations
{
    public class InMemoryStudentRepository : IStudentRepository
    {
        private readonly List<Student> _students = new List<Student>();

        public Student GetById(Guid id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public void Add(Student student)
        {
            _students.Add(student);
        }

        public void Update(Student student)
        {
            var existingStudent = _students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
            {
                existingStudent.UpdateInfo(student.Name, student.StudentNumber);
            }
        }

        public void Delete(Guid id)
        {
            var studentToRemove = _students.FirstOrDefault(s => s.Id == id);
            if (studentToRemove != null)
            {
                _students.Remove(studentToRemove);
            }
        }
    }
}