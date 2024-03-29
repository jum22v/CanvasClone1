using Library.CanvasClone1.Models;
using Library.CanvasClone1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CanvasClone.ViewModels
{
    public class PersonDetailViewModel
    {
        public string Name { get; set; }
        public string ClassificationString { get; set; }

        public void AddPerson()
        {
            StudentClass classification;
            switch (ClassificationString)
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
            StudentService.Current.Add(new Student { Name = Name, Classification = classification });
            Shell.Current.GoToAsync("//Instructor");
        }
    }
}
