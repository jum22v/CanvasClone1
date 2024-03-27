using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CanvasClone1.Models
{
    public class Assignment
    {
        private static int lastId = 0;
        public int ID
        {
            get; private set;
        }
        public string? Name { set; get; }
        public string? Description { set; get; }
        public decimal? Totalavailablepoints { set; get; }
        public DateTime Duedate { set; get; }

        public Assignment()
        {
            ID = ++lastId;
        }
        public override string ToString()
        {
            return $"{ID}. ({Duedate}) {Name}";
        }

    }
}
