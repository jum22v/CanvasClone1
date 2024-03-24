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
        private int id = 0;
        public int ID { 
            get
            {
                if (id == 0)
                {
                    id = ++lastId;
                }
                return id;
            }
        }
        public string? Name { set; get; }
        public string? Description { set; get; }
        public decimal? Totalavailablepoints { set; get; }
        public DateTime Duedate { set; get; }

        public override string ToString()
        {
            return $"([{ID}] - {Duedate}) {Name}";
        }

    }
}
