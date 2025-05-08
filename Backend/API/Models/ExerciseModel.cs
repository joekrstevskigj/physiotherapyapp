namespace API.Models
{
    public class ExerciseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Repetitions { get; set; }
        public int Sets { get; set; }
        public int DurationSeconds { get; set; }
    }
}
