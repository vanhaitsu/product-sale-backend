using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    public class ChatMessage : BaseEntity
    {
        public Guid AccountID { get; set; }
        public string Message { get; set; } = null!;
        public DateTime SentAt { get; set; } = DateTime.Now;
        public Account Account { get; set; } = null!;
    }
}
