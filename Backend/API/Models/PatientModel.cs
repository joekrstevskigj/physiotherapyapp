namespace API.Models
{
    public class PatientModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string LastName { get; set; } = "";

        public List<int> Exercises { get; set; } = [];
    }
}
