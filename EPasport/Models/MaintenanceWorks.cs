using System;

namespace EPasport.Models
{
    public class MaintenanceWorks
    {
        public int MaintenanceWorksId { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public string NameEngineer { get; set; }
        public int Price { get; set; }
        public int TechObjectId { get; set; }
        public TechObject TechObject { get; set; } 
    }
}
