namespace Ambev.DeveloperEvaluation.Domain.Common
{
    public class PaginatedSearchBase
    {
        private int? _page;
        private int? _pageSize;

        public virtual int DefaultPageSize => 20;
        public virtual int MaxPageSize => 50;

        public virtual int? CurrentPage
        { 
            get => _page; set 
            {
                if (value == null || value < 1) 
                    _page = 1;
                else 
                    _page = value;
            }
        }
        public virtual int? PageSize
        {
            get => _pageSize; set
            {
                if (value == null || value < 1)
                    _pageSize = DefaultPageSize;
                else if (value > MaxPageSize)
                    _pageSize = MaxPageSize;
                else
                    _pageSize = value;
            }
        }

        public PaginatedSearchBase() { }

        public PaginatedSearchBase(int? currentPage, int? pageSize)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
        }
    }
}
