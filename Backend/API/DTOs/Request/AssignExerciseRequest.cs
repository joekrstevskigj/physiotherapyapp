namespace API.DTOs.Request
{
    using System.ComponentModel.DataAnnotations;

    public record AssignExerciseRequest
    {
        [Required(ErrorMessage = "Patient ID is required.")]
        public int PatientId { get; set; }

        [Required(ErrorMessage ="Exercises IDs is required.")]
        public required List<int> ExercisesId { get; set; }
    }
}
