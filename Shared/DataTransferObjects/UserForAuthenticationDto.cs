using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record UserForAuthenticationDto
    {
        [Required(ErrorMessage = "User name is required")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password name is requred")]
        public string? Password { get; init; }
    }
}
