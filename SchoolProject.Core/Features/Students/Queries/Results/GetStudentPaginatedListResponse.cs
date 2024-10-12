namespace SchoolProject.Core.Features.Students.Queries.Results
{
    public class GetStudentPaginatedListResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string DepartmentName { get; set; }

        //public GetStudentPaginatedListResponse(int id, string name, string address, string phone, string departmentName)
        //{
        //    Id = id;
        //    Name = name;
        //    Address = address;
        //    Phone = phone;
        //    DepartmentName = departmentName;
        //}
    }
}
