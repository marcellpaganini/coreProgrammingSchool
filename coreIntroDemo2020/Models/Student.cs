using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreIntroDemo2020.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = ("First name cannot be longer than 2-50 characters"))]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = ("Last name cannot be longer than 30 characters"))]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {

            get => $"{FirstName} {LastName}";

        }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "This is not a valid email address")]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }


    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = ("Enter a name between 2 and 50 characters"))]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required]
        [Range(1, 20)]
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }

    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }
        public Grade? Grade { get; set; }

        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
    }
}