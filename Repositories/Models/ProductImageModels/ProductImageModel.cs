using Repositories.Enums;

namespace Repositories.Models.ProductImageModels
{
    public class ProductImageModel
    {
        public Guid Id { get; set; }
        public Guid ProductID { get; set; }
        public string ImgUrl { get; set; } = null!;
        public GeneralStatus Status { get; set; }
    }
}
