using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BonjeMetBonten.Models
{
    public class Koppel
    {
        [Key]
        public int Id { get; set; }
        public int VideoId { get; set; }
        public Video Video { get; set; }
        public int OnderwerpId { get; set; }
        public Onderwerp Onderwerp { get; set; }
    }
}
