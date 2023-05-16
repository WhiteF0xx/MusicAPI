using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPIV1.Data;
using MusicAPIV1.DTO;
using MusicAPIV1.Models;
using MusicAPIV1.Services;

namespace MusicAPIV1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService srv;
        private readonly IMapper mapper;
        public GroupController(IGroupService _srv, IMapper _mapper)
        {
            this.srv = _srv;
            this.mapper = _mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GroupDTO>>> GetAllGroups()
        {
            var groups = await srv.GetAllGroups();
            var resultDTO = this.mapper.Map<List<GroupDTO>>(groups);
            if (resultDTO == null)
            {
                NotFound("Group List Emplty");
            }

            return Ok(resultDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Group?>> GetSingleGroup(int id)
        {
            var result = await this.srv.GetGroupByID(id);
            if (result == null)
                return NotFound("Group not found");
            return Ok(result);
        }

        [HttpGet("byGenreId/{id}")]
        public async Task<ActionResult<Group?>> GetGroupsByGenre(int id)
        {
            var result = await this.srv.GetGroupsByGenre(id);
            if (result == null)
                return NotFound("Group not found");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Group>>> AddGroup(Group group)
        {
            var result = await this.srv.AddGroup(group);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Group>>> UpdateleGroup(int id, Group _group)

        {
            var result = await this.srv.UpdateGroup(id, _group);
            if (result is null)
                return NotFound("Group not found.");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Group>>> DeleteGroup(int id)
        {
            var result = await this.srv.DeleteGroup(id);
            if (result is null)
                return NotFound("Group Not Found");
            return Ok(result);
        }
    }
}
