using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistration.Core.Entities;
using UniversityRegistration.Core.Mediator.Queries;

namespace UniversityRegistration.Core.Mediator.Queries
{
    public class GetStudentCoursesQuery : IQuery<IEnumerable<Course>>
    {
        public Guid StudentId { get; }

        public GetStudentCoursesQuery(Guid studentId)
        {
            StudentId = studentId;
        }
    }
}