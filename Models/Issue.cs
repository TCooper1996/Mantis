namespace Mantis.Models
{
    public enum Severity
    {
        Low,
        Medium,
        High
    }
    
    public class Issue
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public Severity Severity { get; set; }
        
        public Project Project { get; set; }
        
    }
}