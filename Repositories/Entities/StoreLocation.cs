using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    [Table("StoreLocation")]
    public class StoreLocation : BaseEntity
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Address { get; set; } = null!;
    }
}
