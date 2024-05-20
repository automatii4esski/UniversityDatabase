using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace UniversityDatabase.Models
{
    [Table("faculty")]
    public class Faculty
    {
        [Column("id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; } = "";

        [Column("phone")]
        [Required]
        public string Phone { get; set; } = "";

        [Column("dean_id")]
        public int DeanId { get; set; }
        public virtual Dean Dean { get; set; }
    }
}
