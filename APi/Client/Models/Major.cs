using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models;

[Table("tb_m_majors")]
public class Major
{

    public int Code { get; set; }

    public string Name { get; set; }

    public int FacultyCode { get; set; }
}


