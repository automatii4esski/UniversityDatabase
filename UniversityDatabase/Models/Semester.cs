using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityDatabase.Models
{
    [Table("semester")]
    public class Semester
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public byte Id { get; set; }

        [Column("number")]
        [Required]
        public byte Number { get; set; }
    }
}
