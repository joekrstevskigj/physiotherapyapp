namespace API.Interfaces.Services
{
    using API.DTOs.Request;
    using API.DTOs.Response;

    public interface IExercisesService
    {
        Task<ExerciseDto?> GetExerciseAsync(int id);
        Task<List<ExerciseDto>> GetAllExercisesAsync();
    }
}
