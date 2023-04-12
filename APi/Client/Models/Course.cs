using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Models;

[Table("tb_m_courses")]
public class Course
{
    public int Code { get; set; }

    public string Name { get; set; }

    public int Units { get; set; }

    public int? MajorCode { get; set; }

}
