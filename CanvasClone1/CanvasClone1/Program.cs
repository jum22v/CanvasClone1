using CanvasClone1.Helpers;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            var studentHelper = new StudentHelper();
            var courseHelper = new CourseHelper();
            bool cont = true;

            while (cont)
            {
                Console.WriteLine("1. Maintain Students");
                Console.WriteLine("2. Maintain Courses");
                Console.WriteLine("3. Exit");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {   
                    if(result == 1)
                    {
                        DisplayStudentMenu(studentHelper);
                    } else if (result == 2)
                    {
                        DisplayCourseMenu(courseHelper);
                    } else if (result == 3)
                    {
                        cont = false;
                    }
                }
            }
        }
        
        static void DisplayStudentMenu(StudentHelper studentHelper)
        {
            Console.WriteLine("1. Add a student");
            Console.WriteLine("2. List all enrolled students");
            Console.WriteLine("3. Update student enrollment");
            Console.WriteLine("4. Search for a student");

            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                if (result == 1)
                {
                    studentHelper.AddOrUpdateStudent();
                }
                else if (result == 2)
                {
                    studentHelper.ListStudents();
                }
                else if (result == 3)
                {
                    studentHelper.UpdateStudent();
                }
                else if (result == 4)
                {
                    studentHelper.SearchStudents();
                }
            }
        }

        static void DisplayCourseMenu(CourseHelper courseHelper)
        {
            Console.WriteLine("1. Create a new course");
            Console.WriteLine("2. List all courses");
            Console.WriteLine("3. Add a student to a course");
            Console.WriteLine("4. Add an assignment");
            Console.WriteLine("5. Update an assignment");
            Console.WriteLine("6. Remove a student from a course");
            Console.WriteLine("7. Update course information");
            Console.WriteLine("8. Search for a course");

            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                if (result == 1)
                {
                    courseHelper.CreateCourse();
                }
                else if (result == 2)
                {
                    courseHelper.SearchCourses();
                }
                else if (result == 3)
                {
                    courseHelper.AddStudent();
                }
                else if (result == 4)
                {
                    courseHelper.AddAssignment();
                }
                else if (result == 5)
                {
                    courseHelper.UpdateAssignment();
                }
                else if (result == 6)
                {
                    courseHelper.RemoveStudent();
                }
                else if (result == 7)
                {
                    courseHelper.UpdateCourse();
                }
                else if (result == 8)
                {
                    Console.WriteLine("Enter a query:");
                    var query = Console.ReadLine() ?? string.Empty;
                    courseHelper.SearchCourses(query);
                }
            }
        }
    }
}