using Library.CanvasClone1.Database;
using Library.CanvasClone1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CanvasClone1.Services
{
    public class CourseService
    {
        private static CourseService? _instance;

        public static CourseService Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CourseService();
                }
                return _instance;
            }
        }

        private CourseService()
        {
            
        }
        public Course? GetById(int id)
        {
            return FakeDatabase.Courses.FirstOrDefault(p => p.ID == id);
        }

        public void Add(Course course)
        {
            FakeDatabase.Courses.Add(course);
        }

        public void Remove(Course course)
        {
            FakeDatabase.Courses.Remove(course);
        }

        public List<Course> Courses
        {
            get
            {
                return FakeDatabase.Courses;
            }
        }

        public IEnumerable<Course> Search(string query)
        {
            return Courses.Where(s => s.Name.ToUpper().Contains(query.ToUpper())
                || s.Description.ToUpper().Contains(query.ToUpper())
                || s.Code.ToUpper().Contains(query.ToUpper()));
        }
    }
}
