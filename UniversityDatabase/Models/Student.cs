using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using UniversityDatabase.Config;

namespace UniversityDatabase.Models
{
    [Table("student")]
    public class Student
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

        [Column("sex_id")]
        public byte SexId { get; set; }
        public virtual Sex Sex { get; set; }

        [Column("study_group_id")]
        public int StudyGroupId { get; set; }
        public virtual StudyGroup StudyGroup { get; set; } 

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
