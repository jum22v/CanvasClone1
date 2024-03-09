using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CanvasClone1.Models
{
    public class Assignment
    {
        public string? Name { set; get; }
        public string? Description { set; get; }
        public double? Totalavailablepoints { set; get; }
        public string? Duedate { set; get; }
        public Assignment(string? name, string? description, double? totalavailablepoints, string? duedate)
        {
            Name = name;
            Description = description;
            Totalavailablepoints = totalavailablepoints;
            Duedate = duedate;
        }
    }
}
