using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicAPIV1.DTO;
using MusicAPIV1.Models;
using MusicAPIV1.Services;

namespace MusicAPIV1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService srv;
        private readonly IMapper mapper;
        public GenresController(IGenreService _srv, IMapper _mapper)
        {
            this.srv = _srv;
            this.mapper = _mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<Genre>?>> GatAllGenres()
        {
            return await this.srv.GetAllGenre();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre?>> GetGenreByID(int id)
        {
            var result = await this.srv.GetGenreById(id);
            if (result == null)
                return NotFound("Genre not found");
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<Genre>?>> AddGenre(GenreDTO _genre)
        {
            var genre = this.mapper.Map<Genre>(_genre);
            var results = await this.srv.AddGenre(genre);
            return Ok(results);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Genre>?>> DeleteGenre(int id)
        {
            var result = await this.srv.DeleteGenre(id);
            if (result == null)
                return NotFound("The genre not found");
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Genre>?>> UpdateGenre(int id, GenreDTO _genre)
        {
            var genre = this.mapper.Map<Genre>(_genre);
            var result = await this.srv.UpdateGenre(id, genre);
            if (result == null)
                return NotFound("The genre not foung");
            return Ok(result);
        }
    }
}
