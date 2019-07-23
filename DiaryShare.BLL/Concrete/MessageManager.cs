using DiaryShare.BLL.Abstract;
using DiaryShare.DAL.Abstract;
using DiaryShare.Entities.ComplexTypes;
using DiaryShare.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.BLL.Concrete
{
    public class MessageManager : IMessageService
    {
        private IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Add(message);
        }

        public List<MessagingContentForMessagePage> GetMessages(int ownID, int anotherAccountID)
        {
            List<MessagingContentForMessagePage> messages = _messageDal.GetMessages(ownID, anotherAccountID);

            foreach (var item in messages.Where(x => x.IsRead == false && x.MessageTextPosition == "left"))
            {
                _messageDal.Update(new Message
                {
                    IsActive = item.IsActive,
                    IsRead = true,
                    MessageContent = item.MessageContent,
                    MessageID = item.MessageID,
                    SendDate = item.SendDate,
                    MessageMapID = item.MessageMapID
                });
            }

            return messages.OrderBy(x => x.SendDate).ToList();
        }

        public void ChangeIsReadOfMessage(int ownID, int targetID)
        {
            List<Message> messages = _messageDal.GetAll(x => x.MessageMap.FromAccountID == ownID && x.MessageMap.ToAccountID == targetID && x.IsRead==false);

            foreach (Message message in messages)
            {
                message.IsRead = true;
                _messageDal.Update(message);
            }
        }

        public int GetNonReadMessagesCount(int ID)
        {
            return _messageDal.GetAll(x => x.MessageMap.ToAccountID == ID && x.IsRead == false).Count;
        }
    }
}
