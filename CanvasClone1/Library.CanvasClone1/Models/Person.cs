namespace Library.CanvasClone1.Models
{
    public class Person
    {
        public string? Name { set; get; }
        public int ID { set; get; }
        
        public List<Course>? Classes { set; get; }
        public Person()
        {
            Name = string.Empty;
        }

        public override string ToString()
        {
            return $"[{ID}] {Name}";
        }
    }
    
}
