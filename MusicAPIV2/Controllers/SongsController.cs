using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicAPIV2.Contracts;
using MusicAPIV2.DTO;
using MusicAPIV2.Models;
using MusicAPIV2.Repositories;

namespace MusicAPIV2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongRepository songSrv;
        private readonly IMapper mapper;
        public SongsController(ISongRepository _songSrv, IMapper _mapper)
        {
            this.songSrv = _songSrv;
            this.mapper = _mapper;
        }

        [HttpGet(Name = "GetAllSongs")]
        public async Task<ActionResult<List<SongDTO>>> GetAllSongs()
        {
            var result = await this.songSrv.GetAllAsync();
            if (result == null)
                return NotFound("There are no songs");
            return Ok(this.mapper.Map<List<SongDTO>>(result));
        }

        [HttpGet("ByGroupID/{id}", Name = "GetSongsByGroupID")]
        public async Task<ActionResult<List<SongDTO>?>> GetSongsByGroupID(int id)
        {
            var results = await this.songSrv.GetSongsByGroupID(id);
            if (results == null)
                return Ok(null);
            return Ok(this.mapper.Map<List<SongDTO>>(results));
        }
        [HttpGet("BySongID/{id}", Name = "GetSongByID")]
        public async Task<ActionResult<SongDTO?>> GetSongByID(int id)
        {
            var result = await this.songSrv.GetByIDAsync(id);
            if (result == null)
                return Ok(null);
            return Ok(this.mapper.Map<SongDTO>(result));
        }
        [HttpPost]
        public async Task<ActionResult<List<SongDTO>>> AddSong(CreateSongDTO _song)
        {
            var song = this.mapper.Map<Song>(_song);
            var result = await this.songSrv.CreateAsync(song);
            if (result == null)
                return Ok(null);
            return Ok(this.mapper.Map<List<SongDTO>>(result));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SongDTO>?>> DeleteSong(int id)
        {
            var results = await this.songSrv.DeleteSongAsync(id);
            if (results == null)
                return Ok(null);
            return Ok(this.mapper.Map<List<SongDTO>>(results));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<SongDTO>>> UpdateSong(int id, SongDTO _song)
        {
            if (id != _song.Id)
            {
                return BadRequest();
            }
            var result = await this.songSrv.GetByIDAsync(id);
            if (result == null)
            {
                return Ok(null);
            }
            result.songURL = _song.songURL;
            result.SongName = _song.SongName;
            result.GroupId = _song.GroupId;
            result.Id = _song.Id;      
            var songs = await this.songSrv.UpdateSongAsync(result);
            if (songs == null)
                return Ok(null);
            return Ok(this.mapper.Map<List<SongDTO>>(songs));
        }
    }
}
