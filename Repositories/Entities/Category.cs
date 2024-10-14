using Repositories.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    [Table("Category")]
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public GeneralStatus Status { get; set; } = GeneralStatus.Active;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
