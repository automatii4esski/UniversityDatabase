using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityDatabase.Models
{
    [Table("workload")]
    public class Workload
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("total_hours")]
        [Range(0, Int32.MaxValue)]
        public int TotalHours { get; set; } = 0;

        [Column("teacher_id")]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        [Column("study_plan_id")]
        [Required]
        public int StudyPlanId { get; set; }
        public virtual StudyPlan StudyPlan { get; set; }
    }
}
