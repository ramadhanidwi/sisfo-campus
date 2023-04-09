using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace sisfo_campus.Models
{
    [Table("tb_m_faculties")]
    public class Faculty
    {
        [Key, Column("code", TypeName = "nchar(5)")]
        public string Code { get; set; }

        [Required, Column("name"), MaxLength(50)]
        public string Name { get; set; }

        [Required, Column("building")]
        public int Building { get; set; }

        [Required, Column("phone_number"), MaxLength(20)]
        public string PhoneNumber { get; set; }

        //cardinality
        [JsonIgnore]
        public ICollection<Major>? Majors { get; set; }
    }
}
