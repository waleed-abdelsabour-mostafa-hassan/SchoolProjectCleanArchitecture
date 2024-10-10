namespace SchoolProject.Core.Wrappers
{
    public class PaginatedResult<T>
    {
        public PaginatedResult(List<T> data)
        {
            Data = data;
        }

        public List<T> Data { get; set; }

        internal PaginatedResult(bool success, List<T> data = default, List<string> messages = null, int count = 0, int page = 1, int pageSize = 10)
        {
            Data = data;
            CurrentPage = page;
            Succeeded = success;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);
            TotalCount = count;
        }

        public static PaginatedResult<T> Success(List<T> data, int count, int page, int pagesize)
        {
            return new(true, data, null, count, page, pagesize);
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public object Meta { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public List<string> Messages { get; set; } = new();
        public bool Succeeded { get; set; }

    }
}
