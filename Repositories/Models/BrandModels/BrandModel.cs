namespace Repositories.Models.BrandModels
{
    public class BrandModel
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; } = null!;
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
    }
}
