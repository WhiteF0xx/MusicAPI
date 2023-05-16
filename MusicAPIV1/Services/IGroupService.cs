
using MusicAPIV1.DTO;
using MusicAPIV1.Models;


namespace MusicAPIV1.Services
{
    public interface IGroupService
    {
        Task<List<Group>?> GetAllGroups();
        Task<Group?> GetGroupByID(int id);
        Task<List<Group>?> AddGroup(Group group);
        Task<List<Group>?> UpdateGroup(int id, Group group);
        Task<List<Group>?> DeleteGroup(int id);
        Task<List<Group>?> GetGroupsByGenre(int genreID);
    }
}