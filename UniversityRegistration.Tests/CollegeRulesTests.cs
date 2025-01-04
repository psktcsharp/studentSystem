using System;
using System.Linq;
using System.Threading.Tasks;
using UniversityRegistration.Core.Entities;
using UniversityRegistration.Core.Implementations;
using UniversityRegistration.Core.Interfaces;
using UniversityRegistration.Core.Mediator;
using UniversityRegistration.Core.Mediator.Commands;
using UniversityRegistration.Core.Rules;
using Xunit;

namespace UniversityRegistration.Tests
{
    public class CollegeRulesTests
    {
        [Fact]
        public async Task MaxCreditHoursRule_ExceedsLimit_ReturnsFalse()
        {
            // Arrange
            IUnitOfWork unitOfWork = new InMemoryUnitOfWork();
            var student = new Student("Test Student", "123456");
            var course1 = new Course("Course 1", 10);
            var course2 = new Course("Course 2", 10);
            var college = new College("Test College");
            college.AddRule(new MaxCreditHoursRule());
            unitOfWork.StudentRepository.Add(student);
            unitOfWork.CourseRepository.Add(course1);
            unitOfWork.CourseRepository.Add(course2);
            unitOfWork.CollegeRepository.Add(college);

            var registerCommand = new RegisterCourseCommand(student.Id, course1.Id);
            var mediator = new Mediator(unitOfWork);
            await mediator.Send(registerCommand);

            // Act
            var registerCommand2 = new RegisterCourseCommand(student.Id, course2.Id);
            var (isValid, errorMessage) = await mediator.Send(registerCommand2);

            // Assert
            Assert.False(isValid);
            Assert.Equal("Maximum credit hours exceeded.", errorMessage);
        }

        [Fact]
        public async Task MaxCreditHoursRule_WithinLimit_ReturnsTrue()
        {
            // Arrange
            IUnitOfWork unitOfWork = new InMemoryUnitOfWork();
            var student = new Student("Test Student", "123456");
            var course1 = new Course("Course 1", 3);

            var college = new College("Test College");
            college.AddRule(new MaxCreditHoursRule());
            unitOfWork.StudentRepository.Add(student);
            unitOfWork.CourseRepository.Add(course1);
            unitOfWork.CollegeRepository.Add(college);


            // Act
            var registerCommand = new RegisterCourseCommand(student.Id, course1.Id);
            var mediator = new Mediator(unitOfWork);
            var (isValid, errorMessage) = await mediator.Send(registerCommand);

            // Assert
            Assert.True(isValid);
            Assert.Empty(errorMessage);
        }
        [Fact]
        public async Task RegisterCourseCommandHandler_ValidRegistration_ReturnsTrue()
        {
            // Arrange
            IUnitOfWork unitOfWork = new InMemoryUnitOfWork();
            var student = new Student("Test Student", "123456");
            var course1 = new Course("Course 1", 3);

            var college = new College("Test College");
            college.AddRule(new MaxCreditHoursRule());
            unitOfWork.StudentRepository.Add(student);
            unitOfWork.CourseRepository.Add(course1);
            unitOfWork.CollegeRepository.Add(college);


            // Act
            var registerCommand = new RegisterCourseCommand(student.Id, course1.Id);
            var mediator = new Mediator(unitOfWork);
            var (isValid, errorMessage) = await mediator.Send(registerCommand);

            // Assert
            Assert.True(isValid);
            Assert.Empty(errorMessage);
        }
        [Fact]
        public async Task RegisterCourseCommandHandler_InvalidRegistration_ReturnsFalse()
        {
            // Arrange
            IUnitOfWork unitOfWork = new InMemoryUnitOfWork();
            var student = new Student("Test Student", "123456");
            var course1 = new Course("Course 1", 10);
            var course2 = new Course("Course 2", 10);
            var college = new College("Test College");
            college.AddRule(new MaxCreditHoursRule());
            unitOfWork.StudentRepository.Add(student);
            unitOfWork.CourseRepository.Add(course1);
            unitOfWork.CourseRepository.Add(course2);
            unitOfWork.CollegeRepository.Add(college);

            var registerCommand = new RegisterCourseCommand(student.Id, course1.Id);
            var mediator = new Mediator(unitOfWork);
            await mediator.Send(registerCommand);

            // Act
            var registerCommand2 = new RegisterCourseCommand(student.Id, course2.Id);
            var (isValid, errorMessage) = await mediator.Send(registerCommand2);

            // Assert
            Assert.False(isValid);
            Assert.Equal("Maximum credit hours exceeded.", errorMessage);
        }
    }
}