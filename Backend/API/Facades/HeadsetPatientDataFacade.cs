namespace API.Facades
{
    using API.DTOs.Response;
    using API.Interfaces.Facades;
    using API.Interfaces.Services;
    using System.Threading.Tasks;

    public class HeadsetPatientDataFacade : IHeadsetPatientDataFacade
    {
        private readonly IPatientService _patientService;
        private readonly IHeadsetService _headsetService;
        private readonly IExercisesService _exercisesService;

        public HeadsetPatientDataFacade(IPatientService patientService, 
            IHeadsetService headsetService, 
            IExercisesService exercisesService)
        {
            _patientService = patientService;
            _headsetService = headsetService;
            _exercisesService = exercisesService;
        }

        public async Task<HeadsetDataDto?> GetHeadsetPageData(int patientId)
        {
            var result = await _headsetService.GetAllHeadsetDataPatientId(patientId)
                .ConfigureAwait(false);

            if (result == null)
            {
                return null;
            }

            result.PatientData = await _patientService.GetPatientAsync(patientId).ConfigureAwait(false);

            var exercisesID = result.ResultOfExercise.Select(e => e.Id).ToArray();
            if (exercisesID != null && exercisesID.Length > 0)
            {
                result.ExercisesAssigned = await _exercisesService.GetExercisesByIdAsync(exercisesID)
                .ConfigureAwait(false);
            }

            return result;
        }
    }
}
