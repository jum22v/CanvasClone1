namespace Library.CanvasClone1.Models
{
    public class Person
    {
        public string? Name { set; get; }
        public int ID { set; get; }
        public StudentClass Classification;
        
        public Dictionary<int, double> Grades { get; set; }
        public List<Course>? Classes { set; get; }
        public Person()
        {
            Name = string.Empty;
            Grades = new Dictionary<int, double>();
            Classes = new List<Course>();
        }

        public override string ToString()
        {
            return $"[{ID}] {Name} - {Classification}";
        }
    }
    public enum StudentClass
    {
        Freshman, Sophomore, Junior, Senior
    }
}
