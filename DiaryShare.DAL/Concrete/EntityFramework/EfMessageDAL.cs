using DiaryShare.Core.DAL.EntityFramework;
using DiaryShare.DAL.Abstract;
using DiaryShare.DAL.Concrete.EntityFramework.Context;
using DiaryShare.Entities.ComplexTypes;
using DiaryShare.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.DAL.Concrete.EntityFramework
{
    public class EfMessageDal : EfEntityRepository<EfContext, Message>, IMessageDal
    {
        public List<MessagingContentForMessagePage> GetMessages(int ownID, int anotherAccountID)
        {
            using (EfContext context = new EfContext())
            {
                IQueryable<MessagingContentForMessagePage> messages = from m in context.Messages
                                               join map in context.MessageMaps
                                               on m.MessageMapID equals map.MessageMapID
                                               where (map.FromAccountID == ownID && map.ToAccountID == anotherAccountID) || (map.FromAccountID == anotherAccountID && map.ToAccountID == ownID)
                                               select new MessagingContentForMessagePage
                                               {
                                                   IsRead = m.IsRead,
                                                   IsActive = m.IsActive,
                                                   MessageID = m.MessageID,
                                                   MessageMapID = m.MessageMapID,
                                                   MessageContent = m.MessageContent,
                                                   SendDate = m.SendDate,
                                                   MessagePosition= map.FromAccountID == ownID ? "col-md-7 pull-right" : "col-md-7 pull-left",
                                                   MessageTextPosition= map.FromAccountID == ownID ? "right" : "left"
                                               };

                return messages.ToList();
            }
        }

    }
}
