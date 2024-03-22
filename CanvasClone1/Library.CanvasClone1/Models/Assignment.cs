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
        public decimal? Totalavailablepoints { set; get; }
        public DateTime Duedate { set; get; }

        public override string ToString()
        {
            return $"({Duedate}) {Name}";
        }

    }
}
