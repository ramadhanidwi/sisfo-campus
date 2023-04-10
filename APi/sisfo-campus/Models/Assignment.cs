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
    public string Name { get; set; }

    [Required, Column("upload_date")]
    public DateTime UploadDate { get; set; }

    [Column("score")]
    public int? Score { get; set; }

    [Column("course_code")]
    public string CourseCode { get; set; }

    [Column("student_nim")]
    public int? StudentNim { get; set; }

    [Column("lecturer_nik")]
    public int LecturerNik { get; set; }

    //Cardinality
    [ForeignKey(nameof(CourseCode))]
    [JsonIgnore]
    public Course? Course { get; set; }
    
    [ForeignKey(nameof(StudentNim))]
    [JsonIgnore]
    public Student? Student{ get; set; }

    [ForeignKey(nameof(LecturerNik))]
    [JsonIgnore]
    public Lecturer? Lecturer{ get; set; }

}
