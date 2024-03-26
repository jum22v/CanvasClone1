using Library.CanvasClone1.Models;
using Library.CanvasClone1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasClone1.Helpers
{
    internal class StudentHelper
    {
        private StudentService studentService;
        private CourseService courseService;

        public StudentHelper()
        {
            studentService = StudentService.Current;
            courseService = CourseService.Current;
        }

        public void AddOrUpdateStudent(Person? selectedStudent = null)
        {
            bool isCreate = false;
            if (selectedStudent == null)
            {
                isCreate = true;
                Console.WriteLine("What is the role of the person?");
                Console.WriteLine("(S)tudent");
                Console.WriteLine("(T)eaching Assistant");
                Console.WriteLine("(I)nstructor");
                var choice = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrEmpty(choice))
                {
                    return;
                }
                if (choice.Equals("S", StringComparison.InvariantCultureIgnoreCase))
                {
                    selectedStudent = new Student();
                } else if (choice.Equals("T", StringComparison.InvariantCultureIgnoreCase))
                {
                    selectedStudent = new TeachingAssistant();
                } else if (choice.Equals("I", StringComparison.InvariantCultureIgnoreCase))
                {
                    selectedStudent = new Instructor();
                }
            }

            Console.WriteLine("What is the name of the person?");
            var name = Console.ReadLine();
            if (selectedStudent is Student)
            {
                Console.WriteLine("What is the classification of the student? [(F)reshman, S(O)phomore, (J)unior, (S)enior]");
                var classification = Console.ReadLine() ?? string.Empty;
                StudentClass classEnum = StudentClass.Freshman;

                if (classification.Equals("O", StringComparison.InvariantCultureIgnoreCase))
                {
                    classEnum = StudentClass.Sophomore;
                }
                else if (classification.Equals("J", StringComparison.InvariantCultureIgnoreCase))
                {
                    classEnum = StudentClass.Junior;
                }
                else if (classification.Equals("S", StringComparison.InvariantCultureIgnoreCase))
                {
                    classEnum = StudentClass.Senior;
                }
                var studentRecord = selectedStudent as Student;
                if (studentRecord != null)
                {
                    studentRecord.Classification = classEnum;
                    selectedStudent.Name = name ?? string.Empty;

                    if (isCreate)
                    {
                        studentService.Add(selectedStudent);
                    }
                }
            }
            else {
                if (selectedStudent != null)
                {
                    selectedStudent.Name = name ?? string.Empty;
                    if (isCreate)
                    {
                        studentService.Add(selectedStudent);
                    }
                }
            }
        }

        public void UpdateStudent()
        {
            Console.WriteLine("Select a person to update: ");
            studentService.Students.ForEach(Console.WriteLine);

            var selection = Console.ReadLine();

            if (int.TryParse(selection, out int selectionInt))
            {
                var selectedStudent = studentService.Students.FirstOrDefault(s => s.ID == selectionInt);
                if (selectedStudent != null)
                {
                    AddOrUpdateStudent(selectedStudent);
                }
            }
        }

        public void ListStudents()
        {
            studentService.Students.ForEach(Console.WriteLine);

            Console.WriteLine("Select a student: ");
            var selection = Console.ReadLine();
            var selectionInt = int.Parse(selection ?? "0");

            Console.WriteLine("Student course list: ");
            courseService.Courses.Where(c => c.Roster.Any(s => s.ID == selectionInt)).ToList().ForEach(Console.WriteLine);
        }

        public void SearchStudents()
        {
            Console.WriteLine("Enter a query:");
            var query = Console.ReadLine() ?? string.Empty;

            studentService.Search(query).ToList().ForEach(Console.WriteLine);
            var selection = Console.ReadLine();
            var selectionInt = int.Parse(selection ?? "0");

            Console.WriteLine("Student course list: ");
            courseService.Courses.Where(c => c.Roster.Any(s => s.ID == selectionInt)).ToList().ForEach(Console.WriteLine);
        }

    }
}
