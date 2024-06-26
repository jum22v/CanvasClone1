﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CanvasClone1.Models
{
    public class Course
    {
        public string Code { 
            get 
            {
                return $"[{ID}] {Prefix}";
            } 
        }

        private static int lastId = 0;
        public string Prefix { get; set; }
        public int ID
        {
            get; private set;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Person> Roster { get; set; }
        public List<AssignmentGroup> AssignmentGroups { get; set; }
        public IEnumerable<Assignment> Assignments
        {
            get
            {
                return AssignmentGroups.SelectMany(ag => ag.Assignments);
            }
        }
        public List<Submission> Submissions { get; set; }
        public List<Module> Modules { get; set; }
        public Course(bool IDincrement = true)
        {    
            Name = string.Empty;
            Description = string.Empty;
            Roster = new List<Person>();
            AssignmentGroups = new List<AssignmentGroup>();
            Submissions = new List<Submission>();
            Modules = new List<Module>();
            Prefix = string.Empty;

            if (IDincrement)
                ID = ++lastId;
        }

        public override string ToString()
        {
            return $"{Code} - {Name}";
        }

        public string DetailDisplay
        {
            get
            {
                return $"{ToString()}\n{Description}\n\n" + 
                    $"Roster:\n{string.Join("\n\t", Roster.Select(s => s.ToString()).ToArray())}\n\n" + 
                    $"Assignments:\n{string.Join("\n\t", AssignmentGroups.Select(a => a.ToString()).ToArray())}\n\n" +
                    $"Modules:\n{ string.Join("\n\t", Modules.Select(m => m.ToString()).ToArray())}";
            }
        }
    }
}
