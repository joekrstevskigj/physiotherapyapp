namespace API.Models
{
    public class HeadsetDataModel
    {
        public int PatiendId { get; set; }

        public List<ExerciseModel> ResultOfExercise { get; set; } = [];
    }
}
