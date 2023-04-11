using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sisfo_campus.Models
{
    [Table("tb_m_students")]
    public class Student
    {
        [Key, Column("nim", TypeName = "nchar(5)")]
        public string Nim { get; set; }

        [Required, Column("first_name"), MaxLength(50)]
        public string FirstName { get; set; }

        [Column("last_name"), MaxLength(50)]
        public string? LastName { get; set; }

        [Required, Column("birthdate")]
        public DateTime BirthDate { get; set; }

        [Required, Column("gender")]
        public GenderEnum Gender { get; set; }

        [Required, Column("phone_number"), MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required, Column("address"), MaxLength(50)]
        public string Address { get; set; }        

        [Required, Column("email"), MaxLength(50)]
        public string Email { get; set; }

        [Column("major_code")]
        public int? MajorCode { get; set; }

        [Column("course_code")]
        public int? CourseCode { get; set; }


        //relasi
        [ForeignKey(nameof(MajorCode))]
        //cardinality
        [JsonIgnore]
        public Major? Major { get; set; }

        //relasi
        [ForeignKey(nameof(CourseCode))]
        //cardinality
        [JsonIgnore]
        public Course? Course { get; set; }

        [JsonIgnore]
        public Account? Account { get; set; }
                
        //cardinality
        [JsonIgnore]
        public ICollection<Assignment>? Assignment { get; set; }

    }
    public enum GenderEnum
    {
        Male,
        Female
    }
}
