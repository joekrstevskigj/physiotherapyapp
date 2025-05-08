namespace API.Repositories
{
    using API.Interfaces.Data;
    using API.Interfaces.Repositories;
    using API.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ExerciseRepository : IExerciseRepository
    {
        private readonly IApplicationData applicationData;

        public ExerciseRepository(IApplicationData applicationData)
        {
            this.applicationData = applicationData;
        }
        public Task<int> AddAsync(ExerciseModel exercise)
        {
            var _exercises = applicationData.Exercises;

            exercise.Id = _exercises[^1].Id + 1;
            _exercises.Add(exercise);

            return Task.FromResult(exercise.Id);
        }

        public Task<List<ExerciseModel>> GetAllAsync()
        {
            var _exercises = applicationData.Exercises;

            return Task.FromResult(_exercises.ToList());
        }

        public Task<ExerciseModel?> GetByIdAsync(int id)
        {
            var _exercises = applicationData.Exercises;

            var exercise = _exercises.FirstOrDefault(e => e.Id == id);

            return Task.FromResult<ExerciseModel?>(exercise);
        }
    }
}
