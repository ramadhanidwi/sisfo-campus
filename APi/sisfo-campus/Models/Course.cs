using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace sisfo_campus.Models
{
    [Table("tb_m_courses")]
    public class Course
    {
        [Key, Column("code")]
        public int Code { get; set; }

        [Required, Column("name"), MaxLength(50)]
        public string Name { get; set; }

        [Required, Column("units")]
        public int Units { get; set; }

        [Column("major_code")]
        public int? MajorCode { get; set; }

        //relasi
        [ForeignKey(nameof(MajorCode))]
        //cardinality
        [JsonIgnore]
        public Major? Major { get; set; }

        //cardinality
        [JsonIgnore]
        public ICollection<Student>? Students { get; set; }

        //cardinality
        [JsonIgnore]
        public ICollection<Assignment>? Assignments { get; set; }
    }
}
