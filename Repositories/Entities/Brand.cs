using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    [Table("Brand")]
    public class Brand : BaseEntity
    {
        public string BrandName { get; set; } = null!;
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
