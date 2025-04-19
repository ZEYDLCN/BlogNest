namespace Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 50;

        private int _pageSize = 10; // ✅ Varsayılan 10 kayıt göster

        public int PageNumber { get; set; } = 1; // ✅ Varsayılan 1. sayfa

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
        public String? OrderBy { get; set; }    
        public String? Fields { get; set; }
    }
}
