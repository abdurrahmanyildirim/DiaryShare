using DiaryShare.BLL.Abstract;
using DiaryShare.DAL.Abstract;
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
    }
}
