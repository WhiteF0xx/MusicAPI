using MusicAPIV2.Models;

namespace MusicAPIV2.Contracts
{
    public interface IGroupRepository : IGenericRepository<Group>
    {
        Task<List<Group>?> GetGroupByGenre(int? genreID);
        Task<Group?> GetGroupByIDWithSongs(int? groupID);

    }
}
