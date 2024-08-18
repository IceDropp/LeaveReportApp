using LeaveReportApp.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveReportApp.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }
        [Required]
        [MaxLength(500)]
        [Display(Name = "Firstname")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(500)]
        [Display(Name = "Lastname")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EnumDataType(typeof(Role))]
        [Display(Name = "Employment")]
        public Role? Roles { get; set; }
        public IList<LeaveReport>? LeaveReports;
    }
}
