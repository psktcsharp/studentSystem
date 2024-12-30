using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityRegistration.Core.Entities
{
    public class Course
    {
        public Guid Id { get; }
        public string Name { get; private set; }
        public int CreditHours { get; private set; }

        public Course(string name, int creditHours)
        {
            Id = Guid.NewGuid();
            Name = name;
            CreditHours = creditHours;
        }

        public void UpdateInfo(string name, int creditHours)
        {
            Name = name;
            CreditHours = creditHours;
        }
    }
}
