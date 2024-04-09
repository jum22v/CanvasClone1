using Library.CanvasClone1.Models;
using Library.CanvasClone1.Services;
using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CanvasClone.ViewModels
{
    class CourseDetailViewModel
    {
        public CourseDetailViewModel()
        {
            course = new Course(false);
        }

        public string Name
        {
            get => course?.Name ?? string.Empty;
            set { if (course != null) course.Name = value; }
        }
        public string Description
        {
            get => course?.Description ?? string.Empty;
            set { if (course != null) course.Description = value; }
        }
        public string Prefix
        {
            get => course?.Prefix ?? string.Empty;
            set { if (course != null) course.Prefix = value; }
        }
        public int Id { get; set; }

        public string CourseCode
        {
            get => course?.Code ?? string.Empty;
        }

        private Course course;

        public void AddCourse(Shell s)
        {
            CourseService.Current.Add(new Course { Name = Name, Prefix = Prefix, Description = Description }) ;
            s.GoToAsync("//Instructor");
        }
    }
}
