namespace API.Interfaces.Repositories
{
    using API.Models;

    public interface IExerciseRepository
    {
        Task<int> AddAsync(ExerciseModel exercise);
        Task<ExerciseModel?> GetByIdAsync(int id);
        Task<List<ExerciseModel>> GetAllAsync();
    }
}
