using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sisfo_campus.Models;

[Table("tb_m_attachment_files")]
public class AttachmentFile : EntityBase
{
    [Key, Column("id")]
    public Int64 Id { get; set; }

    [Required, Column("file_path", TypeName ="nvarchar(255)")]
    public string FilePath { get; set; } = "/upload/blank-doc.txt";

    [Required, Column("content_type", TypeName ="nvarchar(255)")]
    public string ContentType { get; set; }

    [Required, Column("file_name", TypeName ="nvarchar(50)")]
    public string FileName { get; set; }

    [Required, Column("length")]
    public Int64 Length { get; set; }

    //Relation
    [JsonIgnore]
    public Assignment? Assignment{ get; set; }
}
