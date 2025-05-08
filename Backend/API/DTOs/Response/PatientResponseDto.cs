namespace API.DTOs.Response
{
    public record PatientResponseDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<int>? Exercises { get; set; }
    }
}
