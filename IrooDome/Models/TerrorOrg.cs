using System.ComponentModel.DataAnnotations;

namespace IrooDome.Models
{
    public class TerrorOrg
    {
        [Key]
        public int Id { get; set; }
        public int Distance { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

    }
}
