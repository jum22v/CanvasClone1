using Library.CanvasClone1.Models;
using Library.CanvasClone1.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CanvasClone.ViewModels
{
    public class PersonDetailViewModel
    {
        public string Name { get; set; }
        public string ClassificationString { get; set; }

        public int ID { get; set; }

        public PersonDetailViewModel(int id=0) 
        {
            if (id > 0)
            {
                LoadById(id);
            }
        }

        public void LoadById(int id)
        {
            if (id == 0) { return; }
            var person = StudentService.Current.GetById(id) as Student;
            if (person != null)
            {
                Name = person.Name;
                ID = person.ID;
                ClassificationString = ClassToString(person.Classification);
            }

            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(ClassificationString));
        }

        public void AddPerson()
        {
            if (ID <= 0)
            {
                StudentService.Current.Add(new Student { Name = Name, Classification = StringToClass(ClassificationString) });
            }
            else
            {
                var refToUpdate = StudentService.Current.GetById(ID) as Student;
                refToUpdate.Name = Name;
                refToUpdate.Classification = StringToClass(ClassificationString);
            }
            Shell.Current.GoToAsync("//Instructor");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private StudentClass StringToClass(string s)
        {
            StudentClass classification;
            switch (s)
            {
                case "S":
                    classification = StudentClass.Senior;
                    break;
                case "J":
                    classification = StudentClass.Junior;
                    break;
                case "O":
                    classification = StudentClass.Sophomore;
                    break;
                case "F":
                default:
                    classification = StudentClass.Freshman;
                    break;
            }

            return classification;
        }

        private string ClassToString(StudentClass pc)
        {
            var classificationString = string.Empty;
            switch (pc)
            {
                case StudentClass.Senior:
                    classificationString = "S";
                    break;
                case StudentClass.Junior:
                    classificationString = "J";
                    break;
                case StudentClass.Sophomore:
                    classificationString = "O";
                    break;
                case StudentClass.Freshman:
                default:
                    classificationString = "F";
                    break;
            }
            return classificationString;
        }
    }
}
