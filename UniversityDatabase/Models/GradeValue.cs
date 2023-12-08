using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDatabase.Models
{
    [Table("grade_value")]
    public class GradeValue
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public byte Id { get; set; }

        [Column("value")]
        [Required]
        public string Value { get; set; } = "";

        [Column("form_of_control_id")]
        [Required]
        public int FormOfControlId { get; set; }
        public virtual FormOfControl FormOfControl { get; set; }
    }
}
