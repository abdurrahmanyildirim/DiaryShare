using DiaryShare.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.Entities.Concrete
{
    public class Message : IEntity
    {
        public int MessageID { get; set; }
        public int MessageMapID { get; set; }
        public string MessageContent { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsRead { get; set; }

        public virtual MessageMap MessageMap { get; set; }
    }
}
