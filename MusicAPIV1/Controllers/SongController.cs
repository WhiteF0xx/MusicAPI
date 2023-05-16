using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MusicAPIV1.DTO;
using MusicAPIV1.Models;
using MusicAPIV1.Services;

namespace MusicAPIV1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {

        private readonly ISongService srv;
        private readonly IMapper mapper;
        public SongController(ISongService _srv, IMapper _mapper)
        {   
            this.srv = _srv;
            this.mapper = _mapper;
        }

        [HttpGet(Name = "GetAllSongs")]
        public async Task<ActionResult<List<SongDTO>>> GetAllSongs()
        {
            var result = await srv.GetAllSongs();
            if (result == null)
            {
                NotFound("Songs List Empty");
            }
            return Ok(this.mapper.Map<List<SongDTO>>(result));

        }

        [HttpPost]
        public async Task<ActionResult<List<SongDTO>>> AddSong(CreateSongDTO _song)
        {
            var song = this.mapper.Map<Song>(_song);
            var result = await this.srv.AddSong(song);
            if (result == null)
                return NotFound("There are no songs");
            return Ok(this.mapper.Map<List<SongDTO>>(result));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Song>>> DeleteSong(int id)
        {
            var result = await this.srv.DeleteSong(id);
            if (result is null)
                return NotFound("Song Not Found");
            return Ok(this.mapper.Map<List<SongDTO>>(result));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Song>>> UpdateSong(int id, CreateSongDTO _song)
        {
            var song = this.mapper.Map<Song>(_song);
            var result = await this.srv.UpdateSong(id, song);
            if (result is null)
                return NotFound("Song not found.");
            return Ok(this.mapper.Map<List<SongDTO>>(result));
        }

        [HttpGet("BySongID/{id}", Name = "GetSongByID")]
        public async Task<ActionResult<SongDTO?>> GetSongByID(int id)
        {
            var result = await this.srv.GetSongByID(id);
            if (result == null)
                return NotFound("No songs found");
            return Ok(this.mapper.Map<SongDTO>(result));
        }

        [HttpGet("ByGroupID/{id}", Name = "GetSongsByGroupID")]
        public async Task<ActionResult<List<SongDTO>?>> GetSongsByGroupID(int id)
        {
            var results = await this.srv.GetSongsByGroupID(id);
            if (results == null)
                return NotFound("No songs found for this group");
            return Ok(this.mapper.Map<List<SongDTO>>(results));
        }
    }
}
