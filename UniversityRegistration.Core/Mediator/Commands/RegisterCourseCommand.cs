using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistration.Core.Mediator.Commands;

namespace UniversityRegistration.Core.Mediator.Commands
{
    public class RegisterCourseCommand : ICommand<bool>
    {
        public Guid StudentId { get; }
        public Guid CourseId { get; }

        public RegisterCourseCommand(Guid studentId, Guid courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
        }
    }
}
