using Repositories.Common;
using Services.Common;

namespace Services.Models.ProductModels
{
    public class ProductFilterModel : PaginationParameter
    {
        public string Order { get; set; } = "";
        public bool OrderByDescending { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public Guid? CategoryID { get; set; }
        public Guid? BrandId { get; set; }
        public int? Rating { get; set; }
        public string? Search { get; set; }
        protected override int MinPageSize { get; set; } = PaginationConstant.DEFAULT_MIN_PAGE_SIZE;
        protected override int MaxPageSize { get; set; } = PaginationConstant.DEFAULT_MAX_PAGE_SIZE;
    }
}
