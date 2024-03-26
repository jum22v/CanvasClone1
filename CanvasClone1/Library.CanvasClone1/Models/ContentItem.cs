using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CanvasClone1.Models
{
    public class ContentItem
    {
        public string? Name { set; get; }
        public string? Description { get; set; }
        public int ID { set; get; }

        public override string ToString()
        {
            return $"{Name}: {Description}";
        }
    }
}
