using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDatabase.Models
{
    [Table("student_grade")]
    public class StudentGrade
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("grade_value_id")]
        [Required]
        public byte GradeValueId { get; set; }
        public virtual GradeValue GradeValue { get; set; }

        [Column("student_id")]
        [Required]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [Column("study_plan_id")]
        [Required]
        public int StudyPlanId { get; set; }
        public virtual StudyPlan StudyPlan { get; set; }
    }
}
