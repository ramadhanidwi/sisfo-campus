using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sisfo_campus.Models;


[Table("tb_tr_account_roles")]
public class AccountRole
{
    [Key, Column("id")]
    public int Id { get; set; }

    [Required, Column("account_id", TypeName = "nchar(5)")]
    public string AccountId { get; set; }

    [Required, Column("role_id")]
    public int RoleId { get; set; }


    //Cardinality And Relations 
    [ForeignKey(nameof(AccountId))]
    [JsonIgnore]
    public Account? Account { get; set; }

    [ForeignKey(nameof(RoleId))]
    [JsonIgnore]
    public Role? Role { get; set; }
}
