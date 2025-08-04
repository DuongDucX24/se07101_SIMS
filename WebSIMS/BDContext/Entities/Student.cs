using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSIMS.BDContext.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Enrollment Date")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        // Foreign key for Users
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual Users? User { get; set; }
    }
}
