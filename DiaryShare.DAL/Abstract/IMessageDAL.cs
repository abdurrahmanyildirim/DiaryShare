using DiaryShare.Core.DAL;
using DiaryShare.Entities.ComplexTypes;
using DiaryShare.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.DAL.Abstract
{
    public interface IMessageDal : IEntityRepository<Message>
    {
        List<MessagingContentForMessagePage> GetMessages(int ownID, int anotherAccountID);
    }
}
