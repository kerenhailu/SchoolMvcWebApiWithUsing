using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolMvcWebApi.Models
{
    public class Teacher
    {
        public Teacher(int id, string name, string lName, int wage, DateTime birthday)
        {
            Id = id;
            Name = name;
            LName = lName;
            this.wage = wage;
            Birthday = birthday;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LName { get; set; }
        public int wage { get; set; }
        public DateTime Birthday { get; set; }
    }
}