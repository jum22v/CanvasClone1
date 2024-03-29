﻿using Library.CanvasClone1.Database;
using Library.CanvasClone1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CanvasClone1.Services
{
    public class StudentService
    {

        private static StudentService? _instance;

        public IEnumerable<Student?> Students { 
            get 
            { 
                return FakeDatabase.People.Where(p => p is Student).Select(p => p as Student);
            } 
        }

        private StudentService()
        {
          
        }

        public static StudentService Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StudentService();
                }
                return _instance;
            }
        }

        public void Add(Person student)
        {
            FakeDatabase.People.Add(student);
        }

        public void Remove(Person student)
        {
            FakeDatabase.People.Remove(student);
        }

        public IEnumerable<Person?> Search(string query)
        {
            return Students.Where(s => (s != null) && s.Name.ToUpper().Contains(query.ToUpper()));
        }
    }
}
