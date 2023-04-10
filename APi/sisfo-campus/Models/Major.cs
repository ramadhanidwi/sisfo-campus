using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sisfo_campus.Models;

[Table("tb_m_majors")]
public class Major
{
    [Key,Column("code")]
    public int Code { get; set; }

    [Required, Column("name", TypeName = "nvarchar(50)")]
    public string Name { get; set; }

    [Required,Column("faculty_code")]
    public int FacultyCode { get; set; }

    //Cardinality
    [JsonIgnore]
    [ForeignKey(nameof(FacultyCode))]
    public Faculty? Faculty { get; set; }


    [JsonIgnore]
    public ICollection<Course>? Courses { get; set; }
}


