using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistration.Core.Interfaces;

namespace UniversityRegistration.Core.Implementations
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        public IStudentRepository StudentRepository { get; }
        public ICourseRepository CourseRepository { get; }
        public ICollegeRepository CollegeRepository { get; }
        public IRegistrationRepository RegistrationRepository { get; }

        public InMemoryUnitOfWork()
        {
            StudentRepository = new InMemoryStudentRepository();
            CourseRepository = new InMemoryCourseRepository();
            CollegeRepository = new InMemoryCollegeRepository();
            RegistrationRepository = new InMemoryRegistrationRepository();
        }


        public void Save()
        {
            // In memory, nothing to save
        }

        public void Dispose()
        {
            //Nothing to dispose for in memory implementation
        }
    }
}