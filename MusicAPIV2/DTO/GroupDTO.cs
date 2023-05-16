using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicAPIV2.DTO
{
    public class GroupDTO
    {
        
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int GroupGenreID { get; set; }
    }
}
