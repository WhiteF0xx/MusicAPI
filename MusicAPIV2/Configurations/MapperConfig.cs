using AutoMapper;
using MusicAPIV2.DTO;
using MusicAPIV2.Models;

namespace MusicAPIV2.Configurations
{
    public class MapperConfig : Profile
    {

        public MapperConfig() {
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Song, SongDTO>().ReverseMap();
            CreateMap<Song, CreateSongDTO>().ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();
        } 
    }
}
