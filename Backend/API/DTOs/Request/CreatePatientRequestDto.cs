namespace API.DTOs.Request
{
    using System.ComponentModel.DataAnnotations;

    public record CreatePatientRequestDto()
    {
        [Required(ErrorMessage = "First Name is required.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string? LastName { get; set; }
    }
}
