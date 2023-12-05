using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDatabase.Models
{
    [Table("teacher_position")]
    public class TeacherPosition
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public byte Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; } = "";
    }
}
