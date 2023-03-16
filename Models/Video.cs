using System.ComponentModel.DataAnnotations;

namespace BonjeMetBonten.Models
{
    public class Video
    {
        [Key]
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Link { get; set; }
    }
}
