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
        private CourseService courseService;
        private StudentService studentService;

        public CourseHelper() 
        {
            studentService = StudentService.Current;
            courseService = CourseService.Current;
        }

        public void CreateCourse(Course? selectedCourse = null)
        {
            Console.WriteLine("What is the name of the course?");
            var name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the code of the course?");
            var code = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the description of the course?");
            var description = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Which students should be enrolled in the course? (Q to quit)");
            var roster = new List<Person>();
            bool adding = true;
            while (adding)
            {
                studentService.Students.Where(s => !roster.Any(s2 => s2.ID == s.ID)).ToList().ForEach(Console.WriteLine);
                var selection = "Q";
                if (studentService.Students.Any(s => !roster.Any(s2 => s2.ID == s.ID)))
                {
                    selection = Console.ReadLine() ?? string.Empty;
                }

                if (selection.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    adding = false;
                } else
                {   
                    var selectedID = int.Parse(selection);
                    var selectedStudent = studentService.Students.FirstOrDefault(s => s.ID == selectedID);

                    if (selectedStudent != null)
                    {
                        roster.Add(selectedStudent);
                    }
                }
            }

            Console.WriteLine("Would you like to add assignments? (Y/N)");
            var addAssignment = Console.ReadLine() ?? "N";
            var assignments = new List<Assignment>();
            if (addAssignment.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                adding = true;
                while (adding)
                {
                    Console.WriteLine("Name: ");
                    var assignmentName = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Description: ");
                    var assignmentDescription = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("TotalPoints: ");
                    var totalPoints = decimal.Parse(Console.ReadLine() ?? "100");
                    Console.WriteLine("DueDate: ");
                    var dueDate = DateTime.Parse(Console.ReadLine() ?? "01/01/0001");

                    assignments.Add(new Assignment
                    {
                        Name = assignmentName,
                        Description = assignmentDescription,
                        Totalavailablepoints = totalPoints,
                        Duedate = dueDate,
                    });

                    Console.WriteLine("Add more assignments? (Y/N)");
                    addAssignment = Console.ReadLine() ?? "N";
                    if (addAssignment.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                    {
                        adding = false;
                    }
                }
            }

            bool isNewCourse = false;
            if(selectedCourse == null)
            {   
                isNewCourse = true;
                selectedCourse = new Course();
            }

            selectedCourse.Name = name;
            selectedCourse.Code = code;
            selectedCourse.Description = description;
            selectedCourse.Roster = new List<Person>();
            selectedCourse.Roster.AddRange(roster);
            selectedCourse.Assignments = new List<Assignment>();
            selectedCourse.Assignments.AddRange(assignments);
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

        public void SearchCourses()
        {
            Console.WriteLine("Enter a query:");
            var query = Console.ReadLine() ?? string.Empty;

            courseService.Search(query).ToList().ForEach(Console.WriteLine);
        }

    }
}
