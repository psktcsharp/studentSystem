using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistration.Core.Interfaces;

namespace UniversityRegistration.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; }
        ICourseRepository CourseRepository { get; }
        ICollegeRepository CollegeRepository { get; }
        IRegistrationRepository RegistrationRepository { get; }
        void Save();
    }
}