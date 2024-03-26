using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CanvasClone1.Models
{
    public class Module
    {
        private static int lastId = 0;
        private static int id = 0;
        public int ID
        {
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
        public List<ContentItem> Content { set; get; }
        public Module()
        {
            Content = new List<ContentItem>();
        }

        public override string ToString()
        {
            return $"{Name}: {Description}\n" +
                $"\t{string.Join("\n\t", Content.Select(c => c.ToString()).ToArray())}";
        }
    }
}
