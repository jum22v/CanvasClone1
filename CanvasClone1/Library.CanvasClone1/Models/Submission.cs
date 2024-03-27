using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CanvasClone1.Models
{
    public class Submission
    {
        private static int lastId = 0;
        public int ID
        {
            get; private set;
        }

        public int StudentID { get; set; }

        public int AssignmentID { get; set; }

        public string Content { get; set; }

        public Submission()
        {
            ID = ++lastId;
            Content = string.Empty;
        }
    }
}
