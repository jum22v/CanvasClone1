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

            bool cont = true;

            while (cont)
            {
                Console.WriteLine("1. Add a student");
                Console.WriteLine("2. List all enrolled students");
                Console.WriteLine("3. Exit");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                
                    

                    if (result == 1)
                    {
                        studentHelper.CreateStudent();
                    }else if (result == 2)
                    {
                        studentHelper.ListStudents();
                    }else if (result == 3)
                    {
                        cont = false;
                    }
                }
            }
        }
    }
}