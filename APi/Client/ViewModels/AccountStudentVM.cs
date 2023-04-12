﻿using System.ComponentModel.DataAnnotations;

namespace Client.ViewModels;

public class AccountStudentVM
{
    [Display(Name = "Email"), MaxLength(50), EmailAddress]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [StringLength(255, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    public string Password { get; set; }
}
