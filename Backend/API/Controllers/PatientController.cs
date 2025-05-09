using API.DTOs.Request;
using API.DTOs.Response;
using API.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet(nameof(GetAllPatients))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<PatientResponseDto>>> GetAllPatients()
        {
            var patientList = await _patientService.GetAllPatientsAsync().ConfigureAwait(false);

            if (patientList == null || patientList.Count == 0)
            {
                return NotFound("No patients available.");
            }

            return Ok(patientList);
        }

        [HttpGet(nameof(GetPatientById))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PatientResponseDto>> GetPatientById([FromQuery] int patientId)
        {
            if (patientId <= 0)
            {
                return BadRequest("Invalid patient ID.");
            }

            var patient = await _patientService.GetPatientAsync(patientId).ConfigureAwait(false);
            if (patient == null)
            {
                return NotFound($"No patient with ID of {patientId}");
            }

            return Ok(patient);
        }

        [HttpPost(nameof(AddNewPatient))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddNewPatient([FromBody] CreatePatientRequestDto patientToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _patientService.CreatePatientAsync(patientToAdd).ConfigureAwait(false);

            if (result <= 0)
            {
                return BadRequest("Could not add new patient.");
            }

            return CreatedAtAction(nameof(GetPatientById), new { patientId = result }, result);
        }

        [HttpPost(nameof(AssignExerciseAsync))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AssignExerciseAsync([FromBody] AssignExerciseRequest assignData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(assignData == null)
            {
                return BadRequest($"{nameof(assignData)} must be supplied.");
            }

            if (assignData.ExercisesId == null || assignData.ExercisesId.Count <= 0 || assignData.PatientId <= 0)
            {
                return BadRequest("IDs must be supplied.");
            }

            var result = await _patientService.AssingExercise(assignData.PatientId, assignData.ExercisesId).ConfigureAwait(false);

            if(result <= 0)
            {
                return BadRequest("Could not assign exercise to the patient.");
            }

            return Ok(result);
        }
    }
}
