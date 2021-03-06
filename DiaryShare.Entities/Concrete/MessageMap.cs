﻿using DiaryShare.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.Entities.Concrete
{
    public class MessageMap : IEntity
    {
        public MessageMap()
        {
            Messages = new List<Message>();
            //CountOfIsNotReadMessage = Messages.Where(x => x.IsRead == false).Count();
        }

        public int MessageMapID { get; set; }
        [ForeignKey("FromAccount")]
        public int FromAccountID { get; set; }
        [ForeignKey("ToAccount")]
        public int ToAccountID { get; set; }
        public DateTime LastMessageDate { get; set; }
        //public int CountOfIsNotReadMessage { get; set; }

        public virtual Account FromAccount { get; set; }
        public virtual Account ToAccount { get; set; }
        public virtual List<Message> Messages { get; set; }
    }
}
