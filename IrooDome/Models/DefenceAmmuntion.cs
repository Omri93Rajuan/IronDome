using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IrooDome.Models
{
    public class DefenceAmmuntion
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Amount { get; set; }
    }
}
