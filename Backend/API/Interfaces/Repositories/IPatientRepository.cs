namespace API.Interfaces.Repositories
{
    using API.Models;

    public interface IPatientRepository
    {
        Task<int> AddAsync(PatientModel patient);
        Task<PatientModel?> GetByIdAsync(int id);
        Task<List<PatientModel>> GetAllAsync();

        Task<int> AddExerciseAsync(int patientID, int exerciseId);
    }
}
