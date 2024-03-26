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
                
                SetUpRoster(selectedCourse);
                SetUpAssignments(selectedCourse);
                SetUpModules(selectedCourse);
            }

            if(isNewCourse)
            {
                courseService.Add(selectedCourse);
            }
        }

        public void UpdateCourse()
        {
            Console.WriteLine("Select a course to update (code): ");
            courseService.Courses.ForEach(Console.WriteLine);
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

        public void AddStudent()
        {
            Console.WriteLine("Enter the code of the course to add the student to: ");
            courseService.Courses.ForEach(Console.WriteLine);
            var selection = Console.ReadLine();

            var selectedCourse = courseService.Courses.FirstOrDefault(s => s.Code.Equals(selection, StringComparison.InvariantCultureIgnoreCase));
            if (selectedCourse != null)
            {
                studentService.Students.Where(s => !selectedCourse.Roster.Any(s2 => s2.ID == s.ID)).ToList().ForEach(Console.WriteLine);
                if (studentService.Students.Any(s => !selectedCourse.Roster.Any(s2 => s2.ID == s.ID)))
                {
                    selection = Console.ReadLine() ?? string.Empty;
                }
                if (selection != null)
                {
                    var selectedID = int.Parse(selection);
                    var selectedStudent = studentService.Students.FirstOrDefault(s => s.ID == selectedID);
                    if (selectedStudent != null)
                    {
                        selectedCourse.Roster.Add(selectedStudent);
                    }
                }
            }
        }

        public void RemoveStudent()
        {
            Console.WriteLine("Enter the code of the course to remove the student from: ");
            courseService.Courses.ForEach(Console.WriteLine);
            var selection = Console.ReadLine();

            var selectedCourse = courseService.Courses.FirstOrDefault(s => s.Code.Equals(selection, StringComparison.InvariantCultureIgnoreCase));
            if (selectedCourse != null)
            {
                selectedCourse.Roster.ForEach(Console.WriteLine);
                if (selectedCourse.Roster.Any())
                {
                    selection = Console.ReadLine() ?? string.Empty;
                }
                else
                {
                    selection = null;
                }

                if (selection != null)
                {
                    var selectedID = int.Parse(selection);
                    var selectedStudent = studentService.Students.FirstOrDefault(s => s.ID == selectedID);
                    if (selectedStudent != null)
                    {
                        selectedCourse.Roster.Remove(selectedStudent);
                    }
                }
            }
        }

        public void AddAssignment()
        {
            Console.WriteLine("Enter the code of the course to add the assignment to: ");
            courseService.Courses.ForEach(Console.WriteLine);
            var selection = Console.ReadLine();

            var selectedCourse = courseService.Courses.FirstOrDefault(s => s.Code.Equals(selection, StringComparison.InvariantCultureIgnoreCase));
            if (selectedCourse != null)
            {
                selectedCourse.Assignments.Add(CreateAssignment());
            }
        }

        public void AddModule()
        {
            Console.WriteLine("Enter the code of the course to add the module to: ");
            courseService.Courses.ForEach(Console.WriteLine);
            var selection = Console.ReadLine();

            var selectedCourse = courseService.Courses.FirstOrDefault(s => s.Code.Equals(selection, StringComparison.InvariantCultureIgnoreCase));
            if (selectedCourse != null)
            {
                selectedCourse.Modules.Add(CreateModule(selectedCourse));
            }
        }

        public void UpdateModule()
        {
            Console.WriteLine("Enter the code of the course: ");
            courseService.Courses.ForEach(Console.WriteLine);
            var selection = Console.ReadLine();
            
            var selectedCourse = courseService.Courses.FirstOrDefault(s => s.Code.Equals(selection, StringComparison.InvariantCultureIgnoreCase));

            if (selectedCourse != null && selectedCourse.Modules.Any())
            {
                Console.WriteLine("Enter the id for the module to update");
                selectedCourse.Modules.ForEach(Console.WriteLine);

                selection = Console.ReadLine();
                var selectedModule = selectedCourse.Modules.FirstOrDefault(m => m.ID.ToString().Equals(selection, StringComparison.InvariantCultureIgnoreCase));

                if (selectedModule != null)
                {
                    Console.WriteLine("Would you like to modify module name?");
                    selection = Console.ReadLine();
                    if (selection?.Equals("Y", StringComparison.InvariantCultureIgnoreCase) ?? false)
                    {
                        Console.WriteLine("Name:");
                        selectedModule.Name = Console.ReadLine();
                    }
                    Console.WriteLine("Would you like to modify module description?");
                    selection = Console.ReadLine();
                    if (selection?.Equals("Y", StringComparison.InvariantCultureIgnoreCase) ?? false)
                    {
                        Console.WriteLine("Description:");
                        selectedModule.Description = Console.ReadLine();
                    }

                    Console.WriteLine("Would you like to delete content from this module?");
                    selection= Console.ReadLine();
                    if (selection?.Equals("Y", StringComparison.InvariantCultureIgnoreCase) ?? false)
                    {
                        var removing = true;
                        while (removing == true)
                        {


                            selectedModule.Content.ForEach(Console.WriteLine);
                            selection = Console.ReadLine();

                            var contentToRemove = selectedModule.Content.FirstOrDefault(c => c.ID.ToString().Equals(selection, StringComparison.InvariantCultureIgnoreCase));
                            if (contentToRemove != null)
                            {
                                selectedModule.Content.Remove(contentToRemove);
                            }
                            Console.WriteLine("Would you like to remove more content?");
                            selection = Console.ReadLine();
                            if (selection?.Equals("N", StringComparison.InvariantCultureIgnoreCase) ?? false)
                            {
                                removing = false;
                            }
                        }
                    }

                    Console.WriteLine("Would you like to add content? (Y/N)");
                    var choice = Console.ReadLine() ?? "N";
                    while (choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("What type of content?");
                        Console.WriteLine("1. Assignment");
                        Console.WriteLine("2. File");
                        Console.WriteLine("3. Page");
                        var contentChoice = int.Parse(Console.ReadLine() ?? "0");

                        switch (contentChoice)
                        {
                            case 1:
                                var newAssignmentContent = CreateAssignmentItem(selectedCourse);
                                if (newAssignmentContent != null)
                                {
                                    selectedModule.Content.Add(newAssignmentContent);
                                }
                                break;
                            case 2:
                                var newFileContent = CreateFileItem(selectedCourse);
                                if (newFileContent != null)
                                {
                                    selectedModule.Content.Add(newFileContent);
                                }
                                break;
                            case 3:
                                var newPageContent = CreateFileItem(selectedCourse);
                                if (newPageContent != null)
                                {
                                    selectedModule.Content.Add(newPageContent);
                                }
                                break;
                            default:
                                break;
                        }
                        Console.WriteLine("Would you like to add more content? (Y/N)");
                        choice = Console.ReadLine() ?? "N";
                    }
                }
            }
        }
        public void UpdateAssignment()
        {
            Console.WriteLine("Enter the code of the course: ");
            courseService.Courses.ForEach(Console.WriteLine);
            var selection = Console.ReadLine();

            var selectedCourse = courseService.Courses.FirstOrDefault(s => s.Code.Equals(selection, StringComparison.InvariantCultureIgnoreCase));
            if (selectedCourse != null)
            {
                Console.WriteLine("Choose an assignment to update: ");
                selectedCourse.Assignments.ForEach(Console.WriteLine);
                var selectionStr = Console.ReadLine() ?? string.Empty;
                var selectionInt = int.Parse(selectionStr);
                var selectedAssignment = selectedCourse.Assignments.FirstOrDefault(a => a.ID == selectionInt);
                if (selectedAssignment != null)
                {
                    var index = selectedCourse.Assignments.IndexOf(selectedAssignment);
                    selectedCourse.Assignments.RemoveAt(index);
                    selectedCourse.Assignments.Insert(index, CreateAssignment());
                }
            }
        }

        public void RemoveAssignment()
        {
            Console.WriteLine("Enter the code of the course: ");
            courseService.Courses.ForEach(Console.WriteLine);
            var selection = Console.ReadLine();

            var selectedCourse = courseService.Courses.FirstOrDefault(s => s.Code.Equals(selection, StringComparison.InvariantCultureIgnoreCase));
            if (selectedCourse != null)
            {
                Console.WriteLine("Choose an assignment to delete: ");
                selectedCourse.Assignments.ForEach(Console.WriteLine);
                var selectionStr = Console.ReadLine() ?? string.Empty;
                var selectionInt = int.Parse(selectionStr);
                var selectedAssignment = selectedCourse.Assignments.FirstOrDefault(a => a.ID == selectionInt);
                if (selectedAssignment != null)
                {
                    selectedCourse.Assignments.Remove(selectedAssignment);
                }
            }
        }

        public void RemoveModule()
        {
            Console.WriteLine("Enter the code of the course: ");
            courseService.Courses.ForEach(Console.WriteLine);
            var selection = Console.ReadLine();

            var selectedCourse = courseService.Courses.FirstOrDefault(s => s.Code.Equals(selection, StringComparison.InvariantCultureIgnoreCase));
            if (selectedCourse != null)
            {
                Console.WriteLine("Choose a module to delete: ");
                selectedCourse.Modules.ForEach(Console.WriteLine);
                var selectionStr = Console.ReadLine() ?? string.Empty;
                var selectionInt = int.Parse(selectionStr);
                var selectedModule = selectedCourse.Modules.FirstOrDefault(m => m.ID == selectionInt);
                if (selectedModule != null)
                {
                    selectedCourse.Modules.Remove(selectedModule);
                }
            }
        }
        
        private void SetUpRoster (Course c)
        {

            Console.WriteLine("Which students should be enrolled in the course? (Q to quit)");
            bool adding = true;
            while (adding)
            {
                studentService.Students.Where(s => !c.Roster.Any(s2 => s2.ID == s.ID)).ToList().ForEach(Console.WriteLine);
                var selection = "Q";
                if (studentService.Students.Any(s => !c.Roster.Any(s2 => s2.ID == s.ID)))
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
                        c.Roster.Add(selectedStudent);
                    }
                }
            }
        }

        private void SetUpAssignments(Course c)
        {
            Console.WriteLine("Would you like to add assignments? (Y/N)");
            var addAssignment = Console.ReadLine() ?? "N";
            bool adding;
            if (addAssignment.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                adding = true;
                while (adding)
                {
                    c.Assignments.Add(CreateAssignment());

                    Console.WriteLine("Add more assignments? (Y/N)");
                    addAssignment = Console.ReadLine() ?? "N";
                    if (addAssignment.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                    {
                        adding = false;
                    }
                }
            }

        }
        
        private void SetUpModules(Course c)
        {
            Console.WriteLine("Would you like to add modules? (Y/N)");
            var addModule = Console.ReadLine() ?? "N";
            bool adding;
            if (addModule.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                adding = true;
                while (adding)
                {
                    c.Modules.Add(CreateModule(c));

                    Console.WriteLine("Add more modules? (Y/N)");
                    addModule = Console.ReadLine() ?? "N";
                    if (addModule.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                    {
                        adding = false;
                    }
                }
            }
        }
        private Module CreateModule(Course c)
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Description: ");
            var description = Console.ReadLine() ?? string.Empty;

            var module = new Module
            {
                Name = name,
                Description = description
            };
            Console.WriteLine("Would you like to add content? (Y/N)");
            var choice = Console.ReadLine() ?? "N";
            while(choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("What type of content?");
                Console.WriteLine("1. Assignment");
                Console.WriteLine("2. File");
                Console.WriteLine("3. Page");
                var contentChoice = int.Parse(Console.ReadLine() ?? "0");

                switch (contentChoice)
                {
                    case 1:
                        var newAssignmentContent = CreateAssignmentItem(c);
                        if (newAssignmentContent != null)
                        {
                            module.Content.Add(newAssignmentContent);
                        }
                        break;
                    case 2:
                        var newFileContent = CreateFileItem(c);
                        if (newFileContent != null)
                        {
                            module.Content.Add(newFileContent);
                        }
                        break;
                    case 3:
                        var newPageContent = CreateFileItem(c);
                        if (newPageContent != null)
                        {
                            module.Content.Add(newPageContent);
                        }
                        break;
                    default:
                        break;
                }   
                Console.WriteLine("Would you like to add content? (Y/N)");
                choice = Console.ReadLine() ?? "N";
            }

            return module;
        }

        private AssignmentItem? CreateAssignmentItem(Course c)
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Description: ");
            var description = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Which assignment should be added?");
            c.Assignments.ForEach(Console.WriteLine);
            var choice = int.Parse(Console.ReadLine() ?? "-1");
            if(choice >= 0)
            {
                var assignment = c.Assignments.FirstOrDefault(a => a.ID == choice);
                return new AssignmentItem
                {
                    Assignment = assignment,
                    Name = name,
                    Description = description
                };
            }
            return null;
        }

        private FileItem? CreateFileItem(Course c)
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Description: ");
            var description = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter a path to the file:");
            var filepath = Console.ReadLine();

            return new FileItem
            {
                Path = filepath,
                Name = name,
                Description = description
            };
        }

        private PageItem? CreatePageItem(Course c)
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Description: ");
            var description = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter page content");
            var pageBody = Console.ReadLine();

            return new PageItem
            {
                HtmlBody = pageBody,
                Name = name,
                Description = description
            };
        }

        private Assignment CreateAssignment()
        {
            Console.WriteLine("Name: ");
            var assignmentName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Description: ");
            var assignmentDescription = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("TotalPoints: ");
            var totalPoints = decimal.Parse(Console.ReadLine() ?? "100");
            Console.WriteLine("DueDate: ");
            var dueDate = DateTime.Parse(Console.ReadLine() ?? "01/01/0001");

            return new Assignment
            {
                Name = assignmentName,
                Description = assignmentDescription,
                Totalavailablepoints = totalPoints,
                Duedate = dueDate
            };
        }
    }
}
