namespace API.Interfaces.Repositories
{
    using API.Models;

    public interface IHeadsetDataRepository
    {
        Task<List<HeadsetDataModel>> GetAllAsync();
    }
}
