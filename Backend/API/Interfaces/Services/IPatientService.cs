namespace API.Interfaces.Services
{
    using API.DTOs.Request;
    using API.DTOs.Response;

    public interface IPatientService
    {
        Task<int> CreatePatientAsync(CreatePatientRequestDto dto);
        Task<PatientResponseDto?> GetPatientAsync(int id);
        Task<List<PatientResponseDto>> GetAllPatientsAsync();
        Task<int> AssingExercise(int patientId, int exerciseId);
    }
}
