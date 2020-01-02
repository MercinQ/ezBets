using System.ComponentModel.DataAnnotations;

namespace ezBet.WebAPI.Domain
{
    public class ResetPasswordDTO
    {
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        [Required(ErrorMessage = "Confirm Password is required")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string ResetTokenPassword { get; set; }
    }
}
