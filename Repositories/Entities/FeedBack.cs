using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    [Table("FeedBack")]
    public class FeedBack : BaseEntity
    {
        public Guid ProductID { get; set; }
        public Product Product { get; set; } = null!;
        public Guid AccountID { get; set; }
        public Account Account { get; set; } = null!;
        public int Rating { get; set; }
        public string Description { get; set; } = null!;

    }
}
