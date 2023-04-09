using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace sisfo_campus.Models;

[Table("tb_m_accounts")]
public class Account
{
    [Key, Column("student_nim")]
    public int StudentNim { get; set; }

    [Required, Column("password"), MaxLength(255)]
    public string Password { get; set; }

    //Cardinality
    public ICollection<AccountRole>? AccountRoles { get; set; }
    public Student? Student { get; set; }
}
