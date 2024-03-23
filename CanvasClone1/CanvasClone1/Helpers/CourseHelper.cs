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
            bool isNewCourse = false;
            if (selectedCourse == null)
            {
                isNewCourse = true;
                selectedCourse = new Course();
            }

            var choice = "Y";
            if (!isNewCourse)
            {
                Console.WriteLine("Update course code? (Y/N)");
                choice = Console.ReadLine() ?? "N";
            }
            
            if(choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("What is the code of the course?");
                selectedCourse.Code = Console.ReadLine() ?? string.Empty;
            }

            if(!isNewCourse)
            {
                Console.WriteLine("Update course name? (Y/N)");
                choice = Console.ReadLine() ?? "N";
            }
            else
            {
                choice = "Y";
            }
            if (choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("What is the name of the course?");
                selectedCourse.Name = Console.ReadLine() ?? string.Empty;
            }

            if (!isNewCourse)
            {
                Console.WriteLine("Update course description? (Y/N)");
                choice = Console.ReadLine() ?? "N";
            }
            else
            {
                choice = "Y";
            }
            if (choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("What is the description of the course?");
                selectedCourse.Description = Console.ReadLine() ?? string.Empty;
            }

            if (isNewCourse)
            {
                var roster = new List<Person>();
                var assignments = new List<Assignment>();

                Console.WriteLine("Which students should be enrolled in the course? (Q to quit)");
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
                    }
                    else
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

                selectedCourse.Roster = new List<Person>();
                selectedCourse.Roster.AddRange(roster);
                selectedCourse.Assignments = new List<Assignment>();
                selectedCourse.Assignments.AddRange(assignments);
            }

            if(isNewCourse)
            {
                courseService.Add(selectedCourse);
            }
        }

        public void UpdateCourse()
        {
            Console.WriteLine("Select a course to update (code): ");
            SearchCourses();

            var selection = Console.ReadLine();

            var selectedCourse = courseService.Courses.FirstOrDefault(s => s.Code.Equals(selection, StringComparison.InvariantCultureIgnoreCase));
            if (selectedCourse != null)
            {
                CreateCourse(selectedCourse);
            }
        }

        public void SearchCourses(string? query = null)
        {
            if (string.IsNullOrEmpty(query))
            {
                courseService.Courses.ForEach(Console.WriteLine);
            }
            else
            {
                courseService.Search(query).ToList().ForEach(Console.WriteLine);
            }

            Console.WriteLine("Select a course (code): ");
            var code = Console.ReadLine() ?? string.Empty;

            var selectedCourse = courseService
                .Courses
                .FirstOrDefault(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));
            if (selectedCourse != null)
            {
                Console.WriteLine(selectedCourse.DetailDisplay);
            }

        }

    }
}
