namespace API.Controllers
{
    using API.DTOs.Response;
    using API.Interfaces.Services;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseContoller : ControllerBase
    {
        private readonly IExercisesService _exerciseService;

        public ExerciseContoller(IExercisesService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet(nameof(GetAll))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ExerciseDto>>> GetAll() {

            var exerciseList = await _exerciseService.GetAllExercisesAsync().ConfigureAwait(false);

            if (exerciseList == null || exerciseList.Count == 0)
            {
                return NotFound("No exercises available.");
            }

            return Ok(exerciseList);
        }

        [HttpGet(nameof(GetExerciseById))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PatientResponseDto>> GetExerciseById([FromQuery] int exerciseID)
        {
            if (exerciseID <= 0)
            {
                return BadRequest("Invalid exercise ID.");
            }

            var exercise = await _exerciseService.GetExerciseAsync(exerciseID).ConfigureAwait(false);
            if (exercise == null)
            {
                return NotFound($"No patient with ID of {exerciseID}");
            }

            return Ok(exercise);
        }

        [HttpGet(nameof(GetExercisesById))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PatientResponseDto>> GetExercisesById([FromQuery] int[] exerciseID)
        {
            if (exerciseID == null || exerciseID.Length <= 0)
            {
                return BadRequest("Invalid exercise IDs.");
            }

            var exercise = await _exerciseService.GetExercisesByIdAsync(exerciseID).ConfigureAwait(false);
            if (exercise == null || exercise.Count <= 0)
            {
                return NotFound($"No patient with ID of {exerciseID}");
            }

            return Ok(exercise);
        }
    }
}
