using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
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

    [Column("score")]
    public int? Score { get; set; }

    [Column("course_code")]
    public int CourseCode { get; set; }

    [Column("student_nim")]
    public string? StudentNim { get; set; }

    [Column("lecturer_nik")]
    public int LecturerNik { get; set; }

    [Column("attachment_file_id")]
    public Int64 AttachmentFileId { get; set; }

    //Cardinality
    [JsonIgnore]
    [ForeignKey(nameof(CourseCode))]
    public Course? Course { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(StudentNim))]
    public Student? Student{ get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(LecturerNik))]
    public Lecturer? Lecturer{ get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(AttachmentFileId))]
    public ICollection<AttachmentFile>? AttachmentFiles{ get; set; }

}
