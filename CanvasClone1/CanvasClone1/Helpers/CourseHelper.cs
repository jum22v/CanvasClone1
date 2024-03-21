using Library.CanvasClone1.Models;
using Library.CanvasClone1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasClone1.Helpers
{
    public class CourseHelper
    {
        private CourseService courseService = new CourseService();

        public void CreateCourse()
        {
            Console.WriteLine("What is the name of the course?");
            var name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the code of the course?");
            var code = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the description of the course?");
            var description = Console.ReadLine() ?? string.Empty;

            var course = new Course
            {
                Name = name,
                Code = code,
                Description = description
            };

            courseService.Add(course);
        }

        public void ListCourses()
        {
            courseService.Courses.ForEach(Console.WriteLine);
        }
    }
}
