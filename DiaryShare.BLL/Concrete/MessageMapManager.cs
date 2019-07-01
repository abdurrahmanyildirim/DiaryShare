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
    public class MessageMapManager : IMessageMapService
    {
        private IMessageMapDal _messageMapDal;

        public MessageMapManager(IMessageMapDal messageMapDal)
        {
            _messageMapDal = messageMapDal;
        }

        public List<MessagePageData> GetMessages(int id)
        {
            return _messageMapDal.GetMessages(id);
        }

        public List<MessageMap> GetAccounts(int id)
        {
            return _messageMapDal.GetAll(x => x.FromAccountID == id || x.ToAccountID == id);
        }
    }
}
