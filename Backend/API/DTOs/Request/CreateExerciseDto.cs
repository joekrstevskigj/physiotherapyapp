namespace API.DTOs.Request
{
    using System.ComponentModel.DataAnnotations;

    public record CreateExerciseDto
    {
        [Required(ErrorMessage = "Name of the exercise is required.")]
        public string? Name { get; set; }
        public int Repetitions { get; set; }
        public int Sets { get; set; }
        public int DurationSeconds { get; set; }
    }
}
