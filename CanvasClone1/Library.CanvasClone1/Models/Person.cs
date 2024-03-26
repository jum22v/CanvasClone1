namespace Library.CanvasClone1.Models
{
    public class Person
    {
        public string? Name { set; get; }

        private static int lastId = 0;
        public int ID
        {
            get; private set;
        }

        public List<Course>? Classes { set; get; }
        public Person()
        {
            Name = string.Empty;
            ID = ++lastId;
        }

        public override string ToString()
        {
            return $"[{ID}] {Name}";
        }
    }
    
}
