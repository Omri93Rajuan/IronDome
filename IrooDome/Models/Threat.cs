using IrooDome.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IrooDome.Models
{
    public class Threat
    {
        public Threat() 
        {
            status = ThreatStatus.Inactive;
        }
        [Key]
        public int Id { get; set; }

        [NotMapped]
        public int responseTime 
        {
            get
            {
                return org.Distance / type.Speed;
            }
        }

        public TerrorOrg org { get; set; }

        public ThreatAmmunition type { get; set; }

        public ThreatStatus status { get; set; } //inActive /Active /failed /succeeded

        public DateTime? fired_at { get; set; }
    }
}
