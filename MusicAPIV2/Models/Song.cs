using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicAPIV2.Models
{
    [Table("SongsTBL")]
    public class Song
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string SongName { get; set; } = string.Empty;

        [Required, StringLength(150)]
        public string songURL { get; set; } = string.Empty;

        //Navigation Properties
        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }

}
