using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sisfo_campus.Models;

[Table("tb_m_assignments")]
public class Assignment
{
    [Key,Column("id")]
    public int Id { get; set; }

    [Required, Column("name", TypeName = "nvarchar(20)")]
    public string name { get; set; }

    [Required, Column("upload_date")]
    public DateTime UploadDate { get; set; }

    [Column("course_code")]
    public string CourseCode { get; set; }

    [Column("students_nim")]
    public string StudentsNim { get; set; }

    [Column("lecturer_nik")]
    public string LecturerNik { get; set; }

    //Cardinality
    [JsonIgnore]
    public Course? Course { get; set; }

    [JsonIgnore]
    public Student? Student{ get; set; }

    [JsonIgnore]
    public Lecturer? Lecturer{ get; set; }
}
