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
        private StudentService studentService = new StudentService();
        public void AddOrUpdateStudent(Person? selectedStudent = null)
        {
            Console.WriteLine("What is the name of the student?");
            var name = Console.ReadLine();
            Console.WriteLine("What is the id of the student?");
            var id = Console.ReadLine();
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

            bool isCreate = false;
            if (selectedStudent == null)
            {   
                isCreate = true;
                selectedStudent = new Person();
            }

            selectedStudent.Name = name ?? string.Empty;
            selectedStudent.ID = int.Parse(id ?? "0");
            selectedStudent.Classification = classEnum;

            if (isCreate)
            {
                studentService.Add(selectedStudent);
            }
        }

        public void UpdateStudent()
        {
            Console.WriteLine("Select a student to update: ");
            ListStudents();

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
        }

        public void SearchStudents()
        {
            Console.WriteLine("Enter a query:");
            var query = Console.ReadLine() ?? string.Empty;

            studentService.Search(query).ToList().ForEach(Console.WriteLine);
        }

    }
}
