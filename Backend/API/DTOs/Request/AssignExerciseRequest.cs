namespace API.DTOs.Request
{
    using System.ComponentModel.DataAnnotations;

    public record AssignExerciseRequest
    {
        [Required(ErrorMessage = "Patient ID is required.")]
        public int PatientId { get; set; }

        [Required(ErrorMessage ="Exercise ID is required.")]
        public int ExerciseId { get; set; }
    }
}
