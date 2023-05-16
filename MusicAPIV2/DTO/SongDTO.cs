namespace MusicAPIV2.DTO
{
    public class SongDTO
    {

        public int Id { get; set; }
        public string SongName { get; set; } = string.Empty;
        public string songURL { get; set; } = string.Empty;
        public int GroupId { get; set; }

    }
}
