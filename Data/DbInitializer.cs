using System;
using System.Collections.Generic;
using System.Linq;
using Mantis.Models;
using Microsoft.CodeAnalysis;
using Project = Mantis.Models.Project;

namespace Mantis.Data
{
    public class DbInitializer
    {
       public static void Initialize(Context context)
               {
                   context.Database.EnsureCreated();
       
                   // Look for any projects
                   if (context.Project.Any())
                   {
                       return;   // DB has been seeded
                   }

                   var members = new TeamMember[]
                   {
                       new TeamMember {FirstName = "Michael", LastName = "Hobbes", Role = Role.ProjectManager},
                       new TeamMember {FirstName = "Jason", LastName = "Johnson", Role = Role.Developer},
                       new TeamMember {FirstName = "Monique", LastName = "Dexter", Role = Role.ProjectManager},
                       new TeamMember {FirstName = "Peter", LastName = "Peterson", Role = Role.Developer},
                       new TeamMember {FirstName = "Myra", LastName = "Carson", Role = Role.ProjectManager},
                       new TeamMember {FirstName = "Alice", LastName = "Lawry", Role = Role.Developer},
                   };
       
                   var projects = new Project[]
                   {
                   new Project{Title="Supply Chain Optimization", Priority = Priority.High, DateStarted=DateTime.Parse("2019-09-01"), TeamMembers = members.Take(2).ToList()},
                   new Project{Title="FastMaths", Priority = Priority.Medium, DateStarted=DateTime.Parse("2019-04-06"), Deadline = DateTime.Parse("2020-06-15"), TeamMembers = members.Skip(2).Take(2).ToList()},
                   new Project{Title="Armadillo", Priority = Priority.Low, DateStarted=DateTime.Parse("2020-01-01"), Deadline = DateTime.Parse("2021-09-15"), TeamMembers = members.Skip(4).Take(2).ToList()},
                   };

                   var issues = new Issue[]
                   {
                       new Issue
                       {
                           Description = "Items fail to itemize", Severity = Severity.Low, Project = projects[0]
                       },
                       new Issue
                       {
                           Description = "Data not being logged", Severity = Severity.Medium, Project = projects[1]
                       },
                       new Issue {Description = "Network crashes", Severity = Severity.High, Project = projects[2]},
                   };

                   for (int i = 0; i < 6; i++)
                   {
                       members[i].Project = projects[i/2];
                   }
                   

                   //Add issues to projects and add issue and project models to db
                   for (int i = 0; i < 3; i++)
                   {
                       projects[i].Issues = new List<Issue>{issues[i]};
                   }
                   context.TeamMember.AddRange(members);
                   context.Project.AddRange(projects);
                   context.Issue.AddRange(issues);
                   
                   context.SaveChanges();
       
               } 
    }
}