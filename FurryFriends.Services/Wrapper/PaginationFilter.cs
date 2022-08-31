namespace FurryFriends.Services.Wrapper
{
    public class PaginationFilter
    {
        private const int _maxItemsPerPage = 6;
        private int ItemsPerPage;


        public int CurrentPage { get; set; } = 1;
        public int PageSize
        {
            get => ItemsPerPage;
            set => ItemsPerPage = value > _maxItemsPerPage ? _maxItemsPerPage : value;
        }

    }
}