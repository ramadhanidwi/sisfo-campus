using Client.Models;
using System.ComponentModel.DataAnnotations;

namespace Client.ViewModels;

public class RegisterVM
{
    [MaxLength(5)]
    public string Nim { get; set; }

    public string FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public GenderEnum Gender { get; set; }

    [Phone]
    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public string FacultyName { get; set; }

    public string MajorName { get; set; }

    [DataType(DataType.Password)]
    [StringLength(255, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}
