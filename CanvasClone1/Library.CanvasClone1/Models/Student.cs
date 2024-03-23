using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.CanvasClone1.Models
{
    public class Student : Person
    {
        public StudentClass Classification {  get; set; }

        public Dictionary<int, double> Grades { get; set; }

        public Student()
        {
            Grades = new Dictionary<int, double>();
        }

        public override string ToString()
        {
            return $"[{ID}] {Name} - {Classification}";
        }
    }

    public enum StudentClass
    {
        Freshman, Sophomore, Junior, Senior
    }

}
