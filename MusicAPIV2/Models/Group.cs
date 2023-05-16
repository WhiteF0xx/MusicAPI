using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicAPIV2.Models
{

        [Table("GroupsTBL")]
        public class Group
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            [Column("Groupname"), Required, StringLength(60)]
            public string GroupName { get; set; } = string.Empty;

            [Column("Description"), StringLength(200)]
            public string Description { get; set; } = string.Empty;

            //Navigation properties for Relation
            [Column("GenreID"), Required]
            public int GroupGenreID { get; set; }

            public ICollection<Song>? Songs { get; set; }
        }

}
