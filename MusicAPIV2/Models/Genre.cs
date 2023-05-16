using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicAPIV2.Models
{
    [Table("GenreTBL")]
    public class Genre
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(40)]
        public string GenreName { get; set; } = string.Empty;
    }

}
