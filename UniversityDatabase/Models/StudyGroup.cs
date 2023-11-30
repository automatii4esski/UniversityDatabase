using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDatabase.Models
{
    [Table("study_group")]
    public class StudyGroup
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; } = "";

        [Column("recruitment_year")]
        [Required]
        public int RecruitmentYear { get; set; } = DateTime.Now.Year;

        [Column("course_id")]
        public byte CourseId { get; set; }
        public virtual Course Course { get; set; }


        [Column("faculty_id")]
        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
