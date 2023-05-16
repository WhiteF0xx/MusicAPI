using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPIV2.Contracts;
using MusicAPIV2.DTO;
using MusicAPIV2.Models;

namespace MusicAPIV2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupRepository groupSrv;
        private readonly IMapper mapper;
        public GroupsController(IGroupRepository _groupSrv, IMapper _mapper) { 
            this.groupSrv = _groupSrv;
            this.mapper = _mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GroupDTO>?>> GetAllGroups()
        {
            var groups = await this.groupSrv.GetAllAsync();
            var resultDTO = this.mapper.Map<List<GroupDTO>>(groups);
            if (resultDTO == null)
            {
                Ok(null);
            }

            return Ok(resultDTO);
        }

        [HttpGet("{id}/{withSongs}")]
        public async Task<ActionResult<Group?>> GetSingleGroup(int id, Boolean withSongs)
        {
            var result = (withSongs) ? await this.groupSrv.GetGroupByIDWithSongs(id) : await this.groupSrv.GetByIDAsync(id);
            if (result == null)
                return Ok(null);
            return Ok(result);
        }
        [HttpGet("byGenreId/{id}")]
        public async Task<ActionResult<Group?>> GetGroupsByGenre(int id)
        {
            var result = await this.groupSrv.GetGroupByGenre(id);
            if (result == null)
                return Ok(null);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<GroupDTO>?>> AddGroup(Group group)
        {
            var result = await this.groupSrv.CreateAsync(group);
            var resultDTO = this.mapper.Map<List<GroupDTO>>(result);
            return Ok(resultDTO);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Group>?>> UpdateleGroup(int id, Group _group)
        {
            if (id != _group.Id)
            {
                return BadRequest();
            }

            var result = await this.groupSrv.GetByIDAsync(id);
            if (result is null)
                return Ok(null);
            result.GroupName = _group.GroupName;
            result.GroupGenreID = _group.GroupGenreID;
            result.Description = _group.Description;
            result.Id = _group.Id;
            try
            {
                var groupsResult = await this.groupSrv.UpdateAsync(result);
                return Ok(groupsResult);

            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Group>?>> DeleteGroup(int id)
        {
            var result = await this.groupSrv.DeleteAsync(id);
            if (result is null)
                return Ok(null);
            return Ok(result);
        }
    }
}
