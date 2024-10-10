using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Instructor : GeneralLocalizableEntities
    {
        public Instructor()
        {
            Instructors = new HashSet<Instructor>();
            InstructorSubjects = new HashSet<InstructorSubject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal? Salary { get; set; }
        public int? DepartmentId { get; set; }


        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Instructors")]
        public virtual Department? department { get; set; }

        [InverseProperty("Instructor")]
        public virtual Department? DepartmentManager { get; set; }

        [ForeignKey(nameof(SupervisorId))]
        [InverseProperty("Instructors")]
        public virtual Instructor? Supervisor { get; set; }

        [InverseProperty("Supervisor")]
        public virtual ICollection<Instructor> Instructors { get; set; }

        [InverseProperty("Instructor")]
        public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; }

    }
}
