using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mantis.Models
{
    public enum Priority
    {
        Low,
        Medium,
        High
    }
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Priority Priority { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DateStarted { get; set; }
        
        [DataType(DataType.Date)]
        public  DateTime? DeadLine { get; set; }
        
        public List<TeamMember> TeamMembers{ get; set;}
        public List<Issue> Issues { get; set; }
    }
}