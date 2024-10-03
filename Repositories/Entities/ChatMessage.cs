using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    [Table("ChatMessage")]
    public class ChatMessage : BaseEntity
    {
        public Guid AccountID { get; set; }
        public string Message { get; set; } = null!;
        public DateTime SentAt { get; set; } = DateTime.Now;
        public Account Account { get; set; } = null!;
    }
}
