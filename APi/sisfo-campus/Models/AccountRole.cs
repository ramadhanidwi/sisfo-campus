using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sisfo_campus.Models;


[Table("tb_tr_account_roles")]
public class AccountRole
{
    [Key, Column("id")]
    public int Id { get; set; }

    [Required, Column("account_id")]
    public int AccountId { get; set; }

    [Required, Column("role_id")]
    public int RoleId { get; set; }


    //Cardinality And Relations 
    [ForeignKey(nameof(AccountId))]
    public Account? Account { get; set; }

    [ForeignKey(nameof(RoleId))]
    public Role? Role { get; set; }
}
