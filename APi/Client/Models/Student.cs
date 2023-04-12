using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models
{
    [Table("tb_m_students")]
    public class Student
    {
        public string Nim { get; set; }

        public string FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public GenderEnum Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public int? MajorCode { get; set; }

        public int? CourseCode { get; set; }

    }
    public enum GenderEnum
    {
        Male,
        Female
    }
}
