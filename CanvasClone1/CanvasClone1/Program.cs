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
                Console.WriteLine("1. Maintain People");
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
            Console.WriteLine("1. Add a person");
            Console.WriteLine("2. List all people");
            Console.WriteLine("3. Update update a person");
            Console.WriteLine("4. Search for a person");

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
            Console.WriteLine("4. Remove a student from a course");
            Console.WriteLine("5. Add an assignment");
            Console.WriteLine("6. Update an assignment");
            Console.WriteLine("7. Remove an assignment");
            Console.WriteLine("8. Create a student submission");
            Console.WriteLine("9. List all submissions for a course");
            Console.WriteLine("10. Add a module to a course");
            Console.WriteLine("11. Update a module");
            Console.WriteLine("12. Remove a module from a course");
            Console.WriteLine("13. Update course information");
            Console.WriteLine("14. Search for a course");

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
                    courseHelper.RemoveStudent();
                }
                else if (result == 5)
                {
                    courseHelper.AddAssignment();
                }
                else if (result == 6)
                {
                    courseHelper.UpdateAssignment();
                }
                else if (result == 7)
                {
                    courseHelper.RemoveAssignment();
                }
                else if (result == 8)
                {
                    courseHelper.AddSubmission();
                }
                else if (result == 9)
                {
                    courseHelper.ListSubmissions();
                }
                else if (result == 10)
                {
                    courseHelper.AddModule();
                }
                else if (result == 11)
                {
                    courseHelper.UpdateModule();
                }
                else if (result == 12)
                {
                    courseHelper.RemoveModule();
                }
                else if (result == 13)
                {
                    courseHelper.UpdateCourse();
                }
                else if (result == 14)
                {
                    Console.WriteLine("Enter a query:");
                    var query = Console.ReadLine() ?? string.Empty;
                    courseHelper.SearchCourses(query);
                }
            }
        }
    }
}