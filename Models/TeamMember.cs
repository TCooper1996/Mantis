using System.Collections.Generic;

namespace Mantis.Models
{
    public enum Role
    {
        ProjectManager,
        Developer,
        Designer,
        Consultant
        
    }
    
    public class TeamMember
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        
        public Project? Project { get; set; }
        
    }
}