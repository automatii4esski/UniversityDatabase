using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace UniversityDatabase.Models
{
    [Table("faculty")]
    public class Faculty
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

        [Column("dean_id")]
        public int DeanId { get; set; }
        public Dean Dean { get; set; }
    }
}
