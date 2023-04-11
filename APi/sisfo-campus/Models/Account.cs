using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sisfo_campus.Models;

[Table("tb_m_accounts")]
public class Account
{
    [Key, Column("student_nim", TypeName = "nchar(5)")]
    public string StudentNim { get; set; }

    [Required, Column("password"), MaxLength(255)]
    public string Password { get; set; }

    //Cardinality
    [JsonIgnore]
    public ICollection<AccountRole>? AccountRoles { get; set; }

    [JsonIgnore]
    public Student? Student { get; set; }
}
