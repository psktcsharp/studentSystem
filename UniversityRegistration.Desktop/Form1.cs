using System;
using System.Linq;
using System.Windows.Forms;
using UniversityRegistration.Core.Entities;
using UniversityRegistration.Core.Implementations;
using UniversityRegistration.Core.Interfaces;
using UniversityRegistration.Core.Mediator;
using UniversityRegistration.Core.Mediator.Commands;
using UniversityRegistration.Core.Mediator.Queries;
using UniversityRegistration.Core.Rules;

namespace UniversityRegistration.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            // Create in-memory unit of work
            IUnitOfWork unitOfWork = new InMemoryUnitOfWork();

            // Create mediator and inject the unit of work
            IMediator mediator = new Mediator(unitOfWork);

            // Create sample data
            var student = new Student("أحمد محمد", "202012345");
            var course = new Course("مقدمة في البرمجة", 3);
            var college = new College("جامعة طرابلس");

            college.AddRule(new MaxCreditHoursRule());
            college.AddRule(new PrerequisiteRule());
            college.AddRule(new NoConflictRule());


            unitOfWork.StudentRepository.Add(student);
            unitOfWork.CourseRepository.Add(course);
            unitOfWork.CollegeRepository.Add(college);

            // Register student for the course using the mediator
            var registerCommand = new RegisterCourseCommand(student.Id, course.Id);
            bool isRegistered = await mediator.Send(registerCommand);

            string message = "";
            if (isRegistered)
            {
                message += $"تم تسجيل الطالب {student.Name} في مادة {course.Name}\n";
            }
            else
            {
                message += $"لم يتم تسجيل الطالب {student.Name} في مادة {course.Name}\n";
            }



            // Get the registered courses for the student
            var getCoursesQuery = new GetStudentCoursesQuery(student.Id);
            var courses = await mediator.Send(getCoursesQuery);

            message += $"المواد المسجلة للطالب {student.Name}:\n";
            foreach (var c in courses)
            {
                message += $"- {c.Name}\n";
            }

            MessageBox.Show(message, "Registration Result");
        }
    }
}