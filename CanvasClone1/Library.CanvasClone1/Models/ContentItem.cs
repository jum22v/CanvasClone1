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
        public string? Path { get; set; }
        public ContentItem(string? name, string? description, string? path)
        {
            Name = name;
            Description = description;
            Path = path;
        }
    }
}
