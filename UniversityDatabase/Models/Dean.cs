using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Hosting;

namespace UniversityDatabase.Models
{
    [Table("dean")]
    public class Dean
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

    }
}
