namespace Library.CanvasClone1.Models
{
    public class Person
    {
        public string? Name { set; get; }
        public StudentClass Classification;
        public enum StudentClass
        {
            FRESHMAN = 1,
            SOPHOMORE = 2,
            JUNIOR = 3,
            SENIOR = 4
        }
        public Dictionary<int, double> Grades { get; set; }
        public List<Course>? Classes { set; get; }
        public Person(string name, StudentClass classification)
        {
            Name = name;
            Classification = classification;
            Grades = new Dictionary<int, double>();
            Classes = new List<Course>();
        }
    }
}
