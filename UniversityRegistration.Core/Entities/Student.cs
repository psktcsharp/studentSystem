using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityRegistration.Core.Entities
{
    public class Student
    {
        public Guid Id { get; }
        public string Name { get; private set; }
        public string StudentNumber { get; private set; }

        public Student(string name, string studentNumber)
        {
            Id = Guid.NewGuid();
            Name = name;
            StudentNumber = studentNumber;
        }
        public void UpdateInfo(string name, string studentNumber)
        {
            Name = name;
            StudentNumber = studentNumber;
        }
    }
}
