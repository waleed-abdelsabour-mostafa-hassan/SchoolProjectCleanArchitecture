using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Student : GeneralLocalizableEntities
    {
        public Student()
        {
            StudentSubjects = new HashSet<StudentSubject>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(200)]
        public string? NameAr { get; set; }

        [StringLength(200)]
        public string? NameEn { get; set; }

        [StringLength(400)]
        public string? AddressAr { get; set; }

        [StringLength(400)]
        public string? AddressEn { get; set; }

        [StringLength(100)]
        public string? Phone { get; set; }

        public int? DeptId { get; set; }

        [ForeignKey("DeptId")]
        [InverseProperty("Students")]
        //[InverseProperty(nameof(Department.Students))]
        public virtual Department? Department { get; set; }

        [InverseProperty("Student")]
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }


    }
}
