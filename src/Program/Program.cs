using System;

namespace efAdventures.Program
{
    using Controller;
    using Infrastructure;
    using Model;
    class Program
    {
        static void Main(string[] args)
        {
            StudentController sc = new StudentController(new SchoolContextDesignFactory().CreateDbContext(args));
            sc.AddStudent("Student 1");
            sc.AddStudent("Student 2");

            foreach (Student s in sc.GetAllStudents())
            {
                Console.WriteLine(s.Id + " - " + s.Name);
            }

            Console.ReadLine();
        }
    }
}
