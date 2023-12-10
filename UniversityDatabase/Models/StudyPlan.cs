using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityDatabase.Models
{
    [Table("study_plan")]
    public class StudyPlan
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("total_hours")]
        [Required]
        [Range(0, Int32.MaxValue)]
        public int TotalHours { get; set; }

        [Column("remaining_hours")]
        [Required]
        public int RemainingHours { get; set; }

        [Column("course_id")]
        public byte CourseId { get; set; }
        public virtual Course Course { get; set; }

        [Column("semester_id")]
        public byte SemesterId { get; set; }
        public virtual Semester Semester { get; set; }

        [Column("subject_id")]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        [Column("form_of_control")]
        public int FormOfControlId { get; set; }
        public virtual FormOfControl FormOfControl { get; set; }

        [Column("type_of_occupation")]
        public int TypeOfOccupationId { get; set; }
        public virtual TypeOfOccupation TypeOfOccupation { get; set; }

        [Column("study_group_id")]
        public int StudyGroupId { get; set; }
        public virtual StudyGroup StudyGroup { get; set; }
    }
}
