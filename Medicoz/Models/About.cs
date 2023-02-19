using System.ComponentModel.DataAnnotations.Schema;

namespace Medicoz.Models
{
    public class About
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Desc { get; set; }
        public string? BigImageUrl { get; set; }
        public string? MiddleImageUrl { get; set; }
        public string? SmallImageUrl { get; set; }
        [NotMapped]
        public IFormFile? BigImage { get; set; }
        [NotMapped]
        public IFormFile? MiddleImage { get; set; }
        [NotMapped]
        public IFormFile? SmallImage { get; set; }
    }
}
