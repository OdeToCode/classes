using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new ClassDB();
            
            AddStudents(ctx);
            AddClasses(ctx);
            ctx.SaveChanges();
			
            AssociateStudentsWithClasses(ctx);

			DeleteClasses(ctx);
        	DeleteStudentsFromPhysics(ctx);        	
        	DeleteStudentsFromClasses(ctx);

        }

    	private static void DeleteClasses(ClassDB ctx)
    	{
    		var classes = ctx.Classes.ToList();

			foreach(var @class in classes)
			{
				ctx.DeleteObject(@class);
			}
    		ctx.SaveChanges();
    	}

    	private static void DeleteStudentsFromPhysics(ClassDB ctx)
    	{
    		var physics = ctx.Classes.First(c => c.Name == "Physics");
    		physics.Students.Clear();
    		ctx.SaveChanges();
    	}

    	private static void DeleteStudentsFromClasses(ClassDB ctx)
    	{
    		var students = ctx.Students.ToList();
			foreach(var student in students)
			{
				ctx.DeleteObject(student);
			}
    		ctx.SaveChanges();
    	}

    	private static void AssociateStudentsWithClasses(ClassDB ctx)
        {
            var students = ctx.Students.ToList();
            var physics = ctx.Classes.First(c => c.Name == "Physics");
            
            foreach(var student in students)
            {
                physics.Students.Add(student);    
            }

            var music = ctx.Classes.First(c => c.Name == "Music");

            foreach(var student in students.Take(2))
            {
                music.Students.Add(student);
            }

            var art = ctx.Classes.First(c => c.Name == "Art");
            art.Students.Add(students.First());


            ctx.SaveChanges();
        }
        

        private static void AddClasses(ClassDB ctx)
        {
            ctx.Classes.AddObject(new Class {Name = "Physics"});
            ctx.Classes.AddObject(new Class { Name = "Art" });
            ctx.Classes.AddObject(new Class { Name = "Music" });

        }

        private static void AddStudents(ClassDB ctx)
        {
            ctx.Students.AddObject(
                new Student 
                {
                    Name = "Poonam", 
                    HomeAddress = 
                    {   
                        Street = "Potomac", 
                        City = "Columbia", 
                        State = "MD"
                    }
                });

            ctx.Students.AddObject(
                new Student
                {
                    Name = "Joy",
                    HomeAddress =
                    {
                        Street = "Oak",
                        City = "Hagerstown",
                        State = "MD"
                    }
                });
            ctx.Students.AddObject(
                new Student
                {
                    Name = "Alex",
                    HomeAddress =
                    {
                        Street = "Main",
                        City = "Hagerstown",
                        State = "MD"
                    }
                });
        }
    }
}
