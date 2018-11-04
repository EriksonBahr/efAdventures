using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using efAdventures.Program.Model;
using efAdventures.Program.Infrastructure;

namespace efAdventures.Program.Controller
{
    public class StudentController
    {
        private readonly SchoolContext schoolContext;

        public StudentController (SchoolContext schoolContext)
        {
            this.schoolContext = schoolContext ?? throw new ArgumentNullException(nameof(schoolContext));

            ((DbContext)schoolContext).ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public int AddStudent(string studentName){

            Student student = new Student();
            student.Name = studentName;

            this.schoolContext.Students.Add(student);
            this.schoolContext.SaveChanges();
            return student.Id; 
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return this.schoolContext.Students.ToList();
        }
    }
}