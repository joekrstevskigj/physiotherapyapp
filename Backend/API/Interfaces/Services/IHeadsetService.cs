namespace API.Interfaces.Services
{
    using API.DTOs.Response;

    public interface IHeadsetService
    {
        Task<List<HeadsetDataDto>> GetAllHeadsetData();
    }
}
