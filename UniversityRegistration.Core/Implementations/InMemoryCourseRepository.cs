using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistration.Core.Entities;
using UniversityRegistration.Core.Interfaces;

namespace UniversityRegistration.Core.Implementations
{
    public class InMemoryCourseRepository : ICourseRepository
    {
        private readonly List<Course> _courses = new List<Course>();

        public Course GetById(Guid id)
        {
            return _courses.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Course> GetAll()
        {
            return _courses;
        }

        public void Add(Course course)
        {
            _courses.Add(course);
        }

        public void Update(Course course)
        {
            var existingCourse = _courses.FirstOrDefault(c => c.Id == course.Id);
            if (existingCourse != null)
            {
                existingCourse.UpdateInfo(course.Name, course.CreditHours);
            }
        }

        public void Delete(Guid id)
        {
            var courseToRemove = _courses.FirstOrDefault(c => c.Id == id);
            if (courseToRemove != null)
            {
                _courses.Remove(courseToRemove);
            }
        }
    }
}