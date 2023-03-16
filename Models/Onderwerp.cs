using System.ComponentModel.DataAnnotations;

namespace BonjeMetBonten.Models
{
    public class Onderwerp
    {
        [Key]
        public  int Id { get; set; }
        public string Omschrijving { get; set; }
    }
}
