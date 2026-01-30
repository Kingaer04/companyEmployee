using System.ComponentModel.DataAnnotations;

public record CompanyForCreationDto
{
    [Required(ErrorMessage = "Company name is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the Company Name is 30 characters.")]
    public string? Name { get; init; }

    [Required(ErrorMessage = "Address is a required field.")]
    public string? Address { get; init; }  // Fixed: was "Age", should be "Address"

    [Required(ErrorMessage = "Country is a required field.")]
    public string? Country { get; init; }

    public IEnumerable<EmployeeForCreationDto>? Employees { get; init; }
}