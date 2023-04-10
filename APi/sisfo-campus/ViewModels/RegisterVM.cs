using Microsoft.EntityFrameworkCore.Metadata.Internal;
using sisfo_campus.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sisfo_campus.ViewModels;

public class RegisterVM
{
    
    public int Nim { get; set; }

    public string FirstName { get; set; }   

    public string? LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public GenderEnum Gender { get; set; }

    [Phone]
    public string PhoneNumber { get; set; }
    public string Address { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public string CodeFaculty { get; set; }

    public string NameFaculty { get; set; }

    public int Building { get; set; }

    public string PhoneNumberFaculty { get; set; }

    public string CodeMajor { get; set; }

    public string NameMajor { get; set; }

    public string FacultyCode { get; set; }

    [DataType(DataType.Password)]
    [StringLength(255, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}
