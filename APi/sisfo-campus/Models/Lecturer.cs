using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace sisfo_campus.Models
{
    [Table("tb_m_lecturers")]

    public class Lecturer
    {
        [Key, Column("nik")]
        public int Nik { get; set; }

        [Required, Column("first_name"), MaxLength(50)]
        public string FirstName { get; set; }

        [Column("last_name"), MaxLength(50)]
        public string? LastName { get; set; }

        [Required, Column("address"), MaxLength(50)]
        public string Address { get; set; }

        [Required, Column("phone_number"), MaxLength(20)]
        public string PhoneNumber { get; set; }        

        [Required, Column("degree", TypeName = "nchar(2)")]
        public string Degree { get; set; }

        [Required, Column("gender")]
        public GenderEnum Gender { get; set; }

        [Required, Column("email"), MaxLength(20)]
        public string Email { get; set; }

        [Required, Column("account_id")]
        public int AccountId { get; set; }

        //relasi
        [ForeignKey(nameof(AccountId))]
        //cardinality
        [JsonIgnore]
        public Account? Account { get; set; }

        //cardinality
        [JsonIgnore]
        public ICollection<Assignment>? Assignments { get; set; }

    }

}
