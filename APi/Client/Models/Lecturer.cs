using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Models;

[Table("tb_m_lecturers")]

public class Lecturer
{
    public int Nik { get; set; }

    public string FirstName { get; set; }

    public string? LastName { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    public string Degree { get; set; }

    public GenderEnum Gender { get; set; }

    public string Email { get; set; }

}
