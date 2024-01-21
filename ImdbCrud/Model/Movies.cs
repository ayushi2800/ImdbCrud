using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ImdbCrud.Model
{
    public class Movies
    {
        public int id { get; set; }
        [Required]
        public string? Title { get; set; }
        [StringLength(30)]
        public string? Director { get; set; }
        [DisplayName("Release Date")]
        public int ReleaseYear { get; set; }

    }
}
