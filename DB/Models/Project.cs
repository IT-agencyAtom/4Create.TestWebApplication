using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWebApplication.DB.Models
{
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Project name is required.")]
        public string ProjectName { get; set; }

        public bool ProjectEnabled { get; set; } = true;

        public bool AcceptingNewVisits { get; set; } = false;

        public string? SupportedImageType { get; set; }

        public string AcceptingNewVisitsStr => AcceptingNewVisits ? "Yes" : "No";
    }
}
