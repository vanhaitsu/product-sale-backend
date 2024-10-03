using Repositories.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    [Table("ProductImage")]
    public class ProductImage : BaseEntity
    {
        public Guid ProductID { get; set; }
        public Product Product { get; set; } = null!;
        public string ImgUrl { get; set; } = null!;
        public GeneralStatus Status { get; set; } = GeneralStatus.Active;
    }
}
