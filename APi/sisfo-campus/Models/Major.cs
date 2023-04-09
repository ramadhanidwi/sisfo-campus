using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sisfo_campus.Models;

[Table("tb_m_majors")]
public class Major
{
    [Key,Column("id", TypeName ="nchar(5)")]
    public string Code { get; set; }

    [Required, Column("name", TypeName = "nvarchar(50)")]
    public string Name { get; set; }

    [Column("faculty_code", TypeName = "nchar(5)")]
    public string FacultyCode { get; set; }
}

//Cardinality
[JsonIgnore]
public Faculty Faculty { get; set; }
