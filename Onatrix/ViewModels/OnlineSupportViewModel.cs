using System.ComponentModel.DataAnnotations;

namespace Onatrix.ViewModels;

public class OnlineSupportViewModel
{
    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Email address")]
    [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = string.Empty;
}
