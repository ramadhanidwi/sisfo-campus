using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Models;

[Table("tb_m_faculties")]
public class Faculty
{
    public int Code { get; set; }

    public string Name { get; set; }

    public int Building { get; set; }

    public string PhoneNumber { get; set; }

}
