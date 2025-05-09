namespace API.Interfaces.Facades
{
    using API.DTOs.Response;

    public interface IHeadsetPatientDataFacade
    {
        Task<HeadsetDataDto?> GetHeadsetPageData(int patientId);
    }
}
