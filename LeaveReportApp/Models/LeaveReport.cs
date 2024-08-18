using LeaveReportApp.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveReportApp.Models
{
    public class LeaveReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveReportId { get; set; }

        [Required(ErrorMessage = "Please enter a startdate.")]
        [Display(Name = "Start")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please select an end date.")]
        [Display(Name = "End date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Display(Name = "Application date")]
        [DataType(DataType.Date)]
        public DateTime LeaveReportDate { get; set; }
        [Required]

        [EnumDataType(typeof(LeaveType))]
        [Display(Name = "Reason")]
        public LeaveType LeaveType { get; set; }
        [ForeignKey(name: "Employee")]
        [Display(Name = "Employee")]
        public int FkEmployeeId { get; set; }
        [Display(Name = "Employee ID")]
        public Employee? Employee { get; set; }



        public LeaveReport()
        {
            LeaveReportDate = DateTime.Now; //sets the leave report date automatically when report is created 
        }
    }

}
