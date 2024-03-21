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

        public void CreateCourse(Course? selectedCourse = null)
        {
            Console.WriteLine("What is the name of the course?");
            var name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the code of the course?");
            var code = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the description of the course?");
            var description = Console.ReadLine() ?? string.Empty;

            bool isNewCourse = false;
            if(selectedCourse == null)
            {   
                isNewCourse = true;
                selectedCourse = new Course();
            }

                selectedCourse.Name = name;
                selectedCourse.Code = code;
                selectedCourse.Description = description;

            if(isNewCourse)
            {
                courseService.Add(selectedCourse);
            }
        }

        public void UpdateCourse()
        {
            Console.WriteLine("Select a course to update (code): ");
            ListCourses();

            var selection = Console.ReadLine();

            var selectedCourse = courseService.Courses.FirstOrDefault(s => s.Code.Equals(selection, StringComparison.InvariantCultureIgnoreCase));
            if (selectedCourse != null)
            {
                CreateCourse(selectedCourse);
            }
        }

        public void ListCourses()
        {
            courseService.Courses.ForEach(Console.WriteLine);
        }
    }
}
