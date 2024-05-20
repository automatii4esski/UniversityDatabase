using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using UniversityDatabase.Helpers;

namespace UniversityDatabase.Models
{
    [Table("teacher")]
    public class Teacher
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; } = "";

        [Column("surname")]
        [Required]
        public string Surname { get; set; } = "";

        [Column("patronymic")]
        [Required]
        public string Patronymic { get; set; } = "";

        [Column("date_of_birth", TypeName = "DATE")]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [NotMapped]
        public DateOnly DateOfBirthUI { get => DateOnly.FromDateTime(DateOfBirth); }

        [Column("salary")]
        [Required]
        [Range(0, Int32.MaxValue)]
        public int Salary { get; set; }

        [Column("sex_id")]
        public byte SexId { get; set; }
        public virtual Sex Sex { get; set; }

        [Column("photo_url")]
        public string? PhotoUrl { get; set; }

        [Column("department_id")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [Column("teacher_position_id")]
        public byte TeacherPositionId { get; set; }
        public virtual TeacherPosition TeacherPosition { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                return MyDate.GetAge(DateOfBirth);
            }
        }
    }
}
