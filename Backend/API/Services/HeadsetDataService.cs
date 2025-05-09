namespace API.Services
{
    using API.DTOs.Response;
    using API.Interfaces.Repositories;
    using API.Interfaces.Services;
    using API.Repositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class HeadsetDataService : IHeadsetService
    {
        private readonly IHeadsetDataRepository _headsetRepository;

        public HeadsetDataService(IHeadsetDataRepository headsetRepository)
        {
            _headsetRepository = headsetRepository;
        }

        public async Task<List<HeadsetDataDto>> GetAllHeadsetData()
        {
            var result = await _headsetRepository.GetAllAsync().ConfigureAwait(false);

            return result
                .Select(headsetData => new HeadsetDataDto()
                {
                    PatiendId = headsetData.PatiendId,
                    ResultOfExercise = headsetData.ResultOfExercise
                            .Select(result => new ExerciseDto() { 
                                DurationSeconds = result.DurationSeconds,
                                Id = result.Id,
                                Name = result.Name,
                                Repetitions   = result.Repetitions,
                                Sets = result.Sets
                            }).ToList(),
                })
                .ToList();
        }

        public async Task<HeadsetDataDto?> GetAllHeadsetDataPatientId(int patientId)
        {
            var allHeadsetData = await _headsetRepository.GetAllAsync().ConfigureAwait(false);

            var filteredData = allHeadsetData
                .Where(headsetData => headsetData.PatiendId == patientId)
                .Select(headsetData => new HeadsetDataDto
                {
                    PatiendId = headsetData.PatiendId,
                    ResultOfExercise = headsetData.ResultOfExercise
                        .Select(result => new ExerciseDto
                        {
                            Id = result.Id,
                            Name = result.Name,
                            DurationSeconds = result.DurationSeconds,
                            Repetitions = result.Repetitions,
                            Sets = result.Sets
                        }).ToList()
                })
                .FirstOrDefault();

            return filteredData;
        }
    }
}
