using System;

namespace EPasport.Models
{
    public class TechObject
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Series { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime GuaranteePeriod { get; set; }
    }
}
