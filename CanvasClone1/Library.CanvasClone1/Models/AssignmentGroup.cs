using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CanvasClone1.Models
{
    public class AssignmentGroup
    {
        public List<Assignment> Assignments { get; set; }  

        public int ID { get; private set; }
        private static int lastId;

        public string Name { get; set; }
        public decimal Weight { get; set; }

        public AssignmentGroup() {
            Assignments = new List<Assignment>();
            Name = string.Empty;
            Weight = 1;

            ID = ++lastId;
        }

        public override string ToString()
        {
            return $"[{ID}]  {Name}  ({Weight}%)\n{string.Join("\n", Assignments.Select(s => s.ToString()).ToArray())}";
        }
    }
}
