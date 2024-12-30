using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityRegistration.Core.Entities
{
    public class Registration
    {
        public Guid Id { get; }
        public Student Student { get; private set; }
        public Course Course { get; private set; }
        public DateTime RegistrationDate { get; private set; }

        public Registration(Student student, Course course)
        {
            Id = Guid.NewGuid();
            Student = student;
            Course = course;
            RegistrationDate = DateTime.Now;
        }

        public void UpdateInfo(Student student, Course course)
        {
            Student = student;
            Course = course;
        }
    }
}
