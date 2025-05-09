namespace API.DTOs.Response
{
    using API.Models;

    public class HeadsetDataDto
    {
        public int PatiendId { get; set; }

        public List<ExerciseDto> ResultOfExercise { get; set; } = [];
        public List<ExerciseDto> ExercisesAssigned { get; set; } = [];

        public PatientResponseDto? PatientData { get; set; }
    }
}
