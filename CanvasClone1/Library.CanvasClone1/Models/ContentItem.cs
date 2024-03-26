using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CanvasClone1.Models
{
    public class ContentItem
    {
        private static int lastId = 0;
        private static int id = 0;
        public int ID
        {
            get; private set;
        }
        public string? Name { set; get; }
        public string? Description { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Description}";
        }

        public ContentItem()
        {
            ID = ++lastId;
        }
    }
}
