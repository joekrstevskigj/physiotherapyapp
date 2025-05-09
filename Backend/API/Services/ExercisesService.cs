namespace API.Services
{
    using API.DTOs.Response;
    using API.Interfaces.Repositories;
    using API.Interfaces.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ExercisesService : IExercisesService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExercisesService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<List<ExerciseDto>> GetAllExercisesAsync()
        {
            var result = await _exerciseRepository.GetAllAsync().ConfigureAwait(false);

            return result
                .Select(exercise => new ExerciseDto()
                {
                    Id = exercise.Id,
                    DurationSeconds = exercise.DurationSeconds,
                    Name = exercise.Name,
                    Repetitions = exercise.Repetitions,
                    Sets = exercise.Sets
                })
                .ToList();
        }

        public async Task<ExerciseDto?> GetExerciseAsync(int id)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(id).ConfigureAwait(false);
            return exercise == null
                ? null
                : new ExerciseDto()
                {
                    Id = exercise.Id,
                    DurationSeconds = exercise.DurationSeconds,
                    Name = exercise.Name,
                    Repetitions = exercise.Repetitions,
                    Sets = exercise.Sets
                };
        }

        public async Task<List<ExerciseDto>> GetExercisesByIdAsync(int[] ids)
        {
            var tasks = ids.Select(id => _exerciseRepository.GetByIdAsync(id)).ToArray();
            var exercises = await Task.WhenAll(tasks).ConfigureAwait(false);

            return exercises
                .Where(exercise => exercise != null)
                .Select(exercise => new ExerciseDto
                {
                    Id = exercise.Id,
                    Name = exercise.Name,
                    Repetitions = exercise.Repetitions,
                    Sets = exercise.Sets,
                    DurationSeconds = exercise.DurationSeconds
                })
                .ToList();
        }
    }
}
