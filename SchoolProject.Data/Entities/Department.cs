using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Department : GeneralLocalizableEntities
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
            Instructors = new HashSet<Instructor>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(200)]
        public string? NameAr { get; set; }
        [StringLength(200)]
        public string? NameEn { get; set; }

        public int? InstManagerId { get; set; }


        //[InverseProperty(nameof(Student.Department))]
        [InverseProperty("Department")]
        public virtual ICollection<Student> Students { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }

        //[InverseProperty(nameof(Instructor.Department))]
        [InverseProperty("department")]
        public virtual ICollection<Instructor> Instructors { get; set; }

        [ForeignKey(nameof(InstManagerId))]
        [InverseProperty("DepartmentManager")]
        public virtual Instructor? Instructor { get; set; }

    }
}
