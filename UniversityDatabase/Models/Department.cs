using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace UniversityDatabase.Models
{
    [Table("department")]
    public class Department
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; } = "";

        [Column("phone")]
        [Required]
        public string Phone { get; set; } = "";

        [Column("faculty_id")]
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; } = new();
    }
}
