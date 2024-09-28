using Repositories.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; } = null!;
        public GeneralStatus GeneralStatus { get; set; } = GeneralStatus.Active;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
