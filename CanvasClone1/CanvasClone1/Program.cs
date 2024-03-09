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
            Console.WriteLine("1. Add a student");
            Console.WriteLine("2. Exit");
            var input = Console.ReadLine();
            if(int.TryParse(input, out int result))
            {
                while (result != 2)
                {
                    if (result == 1)
                    {
                        studentHelper.CreateStudent();
                    }

                    input = Console.ReadLine();
                    int.TryParse(input, out result);
                }
            }
        }
    }
}