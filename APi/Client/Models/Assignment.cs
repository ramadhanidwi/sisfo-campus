using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;

namespace Client.Models;

[Table("tb_m_assignments")]
public class Assignment
{
    public int Id { get; set; }

    public string name { get; set; }

    public DateTime UploadDate { get; set; }

    public int? Score { get; set; }

    public int CourseCode { get; set; }

    public string? StudentNim { get; set; }

    public int LecturerNik { get; set; }

}
