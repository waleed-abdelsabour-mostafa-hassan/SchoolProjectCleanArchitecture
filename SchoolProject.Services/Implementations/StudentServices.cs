using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Services.Abstracts;

namespace SchoolProject.Services.Implementations
{
    public class StudentServices : IStudentServices
    {

        #region Fields
        private readonly IStudentRepository _studentRepository;
        #endregion

        #region Constructors
        public StudentServices(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        #endregion

        #region Module Functions
        public async Task<List<Student>> GetStudentsListAsync()
        {
            var students = await _studentRepository.GetStudentsListAsync();
            return students;
        }

        public async Task<Student> GetStudentByIdWithIncludeAsync(int id)
        {
            //var student = _studentRepository.GetByIdAsync(id);
            var student = _studentRepository.GetTableNoTracking()
                                            .Include(d => d.Department)
                                            .Where(x => x.Id == id)
                                            .FirstOrDefault();
            return student;
        }

        public async Task<string> AddAsync(Student student)
        {
            // Check if the name exist or not
            var studentResult = _studentRepository.GetTableNoTracking().Where(x => x.NameAr == student.NameAr && x.NameEn.Equals(student.NameEn)).FirstOrDefault();
            if (studentResult != null) { return "Exists"; }
            // Add student
            await _studentRepository.AddAsync(student);
            return "Success";
        }

        public async Task<bool> IsNameArExists(string nameAr)
        {
            // Check if the name exist or not
            var student = _studentRepository.GetTableNoTracking().Where(x => x.NameAr == nameAr).FirstOrDefault();
            if (student == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task<bool> IsNameEnExists(string nameEn)
        {
            // Check if the name exist or not
            var student = _studentRepository.GetTableNoTracking().Where(x => x.NameEn.Equals(nameEn)).FirstOrDefault();
            if (student == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> IsNameArExistsExcludeSelf(string nameAr, int id)
        {
            // Check if the name exist or not
            var student = await _studentRepository.GetTableNoTracking().Where(x => (x.NameAr == nameAr & !x.Id.Equals(id))).FirstOrDefaultAsync();
            if (student == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task<bool> IsNameEnExistsExcludeSelf(string nameEn, int id)
        {
            // Check if the name exist or not
            var student = await _studentRepository.GetTableNoTracking().Where(x => (x.NameEn == nameEn & !x.Id.Equals(id))).FirstOrDefaultAsync();
            if (student == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<string> EditAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }

        public async Task<string> DeleteAsync(Student student)
        {
            var trans = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }

        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return student;
        }

        public IQueryable<Student> GetStudentsListQueryable()
        {
            var students = _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
            return students;
        }
        public IQueryable<Student> GetStudentsListByDepartmentIdQueryable(int deptId)
        {
            var students = _studentRepository.GetTableNoTracking().Where(x => x.DeptId.Equals(deptId)).AsQueryable();
            return students;
        }
        public IQueryable<Student> FilterStudentsPaginatedQueryable(StudentOrderingEnum orderingEnum, string searchAr, string searchEn)
        {
            var querable = _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
            if (searchAr != null || searchEn != null)
            {
                querable = querable.Where(x => x.NameAr.Contains(searchAr) || x.NameEn.Contains(searchEn) || x.AddressAr.Contains(searchAr) || x.AddressEn.Contains(searchEn));
            }

            switch (orderingEnum)
            {
                case StudentOrderingEnum.Id:
                    querable = querable.OrderBy(x => x.Id);
                    break;
                case StudentOrderingEnum.NameAr:
                    querable = querable.OrderBy(x => x.NameAr);
                    break;
                case StudentOrderingEnum.NameEn:
                    querable = querable.OrderBy(x => x.NameEn);
                    break;
                case StudentOrderingEnum.AddressAr:
                    querable = querable.OrderBy(x => x.AddressAr);
                    break;
                case StudentOrderingEnum.AddressEn:
                    querable = querable.OrderBy(x => x.AddressEn);
                    break;
                case StudentOrderingEnum.DepartmentNameAr:
                    querable = querable.OrderBy(x => x.Department.NameAr);
                    break;
                case StudentOrderingEnum.DepartmentNameEn:
                    querable = querable.OrderBy(x => x.Department.NameEn);
                    break;
                default:
                    querable = querable.OrderBy(x => x.Id);
                    break;
            }

            return querable;

        }
        #endregion

    }
}
