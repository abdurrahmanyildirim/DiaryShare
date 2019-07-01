using DiaryShare.Entities.ComplexTypes;
using DiaryShare.Entities.Concrete;
using System.Collections.Generic;

namespace DiaryShare.BLL.Abstract
{
    public interface IMessageService
    {
        List<MessagingContentForMessagePage> GetMessages(int ownID, int anotherAccountID);
    }
}