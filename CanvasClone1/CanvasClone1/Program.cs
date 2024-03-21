using CanvasClone1.Helpers;
using Library.CanvasClone1.Models;
using System;

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
                Console.WriteLine("1. Add a student");
                Console.WriteLine("2. List all enrolled students");
                Console.WriteLine("3. Update student enrollment");
                Console.WriteLine("4. Search for a student");
                Console.WriteLine("5. Create a new course");
                Console.WriteLine("6. Exit");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {



                    if (result == 1)
                    {
                        studentHelper.AddOrUpdateStudent();
                    } else if (result == 2)
                    {
                        studentHelper.ListStudents();
                    } else if (result == 3)
                    {
                        studentHelper.UpdateStudent();
                    } else if (result == 4)
                    {
                        studentHelper.SearchStudents();
                    }
                    else if (result == 5)
                    {
                        courseHelper.CreateCourse();
                    }
                    else if (result == 6)
                    {
                        cont = false;
                    }
                }
            }
        }
    }
}