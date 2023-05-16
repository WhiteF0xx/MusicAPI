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
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository genreSrv;
        private readonly IMapper mapper;
        public GenreController(IGenreRepository _genreSrv, IMapper _mapper)
        {
            this.genreSrv = _genreSrv;
            this.mapper = _mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genre>?>> GatAllGenres()
        {
            return await this.genreSrv.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genre?>> GetGenreByID(int id)
        {
            var result = await this.genreSrv.GetByIDAsync(id);
            if (result == null)
                return Ok(null);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<Genre>?>> AddGenre(GenreDTO _genre)
        {
            var genre = this.mapper.Map<Genre>(_genre);
            var results = await this.genreSrv.CreateAsync(genre);
            return Ok(results);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Genre>?>> DeleteGenre(int id)
        {
            var result = await this.genreSrv.DeleteAsync(id);
            if (result == null)
                return Ok(null);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Genre>?>> UpdateGenre(int id, Genre _genre)
        {
            if (id != _genre.Id)
            {
                return BadRequest();
            }
            var genre = await this.genreSrv.GetByIDAsync(id);
            if (genre == null)
                return Ok(null);
            genre.Id = _genre.Id;
            genre.GenreName = _genre.GenreName;
            var result = await this.genreSrv.UpdateAsync(genre);
            if (result == null)
                return Ok(null);
            return Ok(result);
        }
    }
}
