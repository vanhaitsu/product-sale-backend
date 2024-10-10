using Repositories.Common;
using Services.Common;

namespace Services.Models.CategoryModels
{
    public class CategoryFilterModel : PaginationParameter
    {
        public string Order { get; set; } = "";
        public bool OrderByDescending { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public string? Search { get; set; }
        protected override int MinPageSize { get; set; } = PaginationConstant.DEFAULT_MIN_PAGE_SIZE;
        protected override int MaxPageSize { get; set; } = PaginationConstant.DEFAULT_MAX_PAGE_SIZE;
    }
}
