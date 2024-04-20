using Library.CanvasClone1.Models;
using Library.CanvasClone1.Services;
using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public int ID { get; set; }

        public CourseDetailViewModel(int id = 0)
        {
            if (id > 0)
            {
                LoadById(id);
            }
        }

        public void LoadById(int id)
        {
            if (id == 0) { return; }
            var course = CourseService.Current.GetById(id) as Course;
            if (course != null)
            {
                Name = course.Name;
                ID = course.ID;
                Prefix = course.Prefix;
                Description = course.Description;
            }

            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Description));
            NotifyPropertyChanged(nameof(Prefix));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string CourseCode
        {
            get => course?.Code ?? string.Empty;
        }

        private Course course;

        public void AddCourse()
        {
            //CourseService.Current.Add(new Course { Name = Name, Prefix = Prefix, Description = Description }) ;
            if (ID <= 0)
            {
                CourseService.Current.Add(new Course { Name = Name, Prefix = Prefix, Description = Description });
            }
            else
            {
                var refToUpdate = CourseService.Current.GetById(ID) as Course;
                refToUpdate.Name = Name;
                refToUpdate.Prefix = Prefix;
                refToUpdate.Description = Description;
            }
            Shell.Current.GoToAsync("//Instructor");
        }

    }
}
