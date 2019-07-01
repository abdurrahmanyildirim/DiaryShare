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
    public class EfMessageMapDal : EfEntityRepository<EfContext, MessageMap>, IMessageMapDal
    {
        public List<MessagePageData> GetMessages(int id)
        {
            using (EfContext context = new EfContext())
            {
                IQueryable<MessagePageData> messageMaps = from map in context.MessageMaps
                                                          join a in context.Accounts
                                                          on map.FromAccountID equals a.AccountID
                                                          where id == map.FromAccountID || id == map.ToAccountID
                                                          select new MessagePageData
                                                          {
                                                              AccountID = map.FromAccountID == id ? map.ToAccountID : map.FromAccountID,
                                                              FirstName = map.FromAccountID == id ? map.ToAccount.FirstName : map.FromAccount.FirstName,
                                                              LastName = map.FromAccountID == id ? map.ToAccount.LastName : map.FromAccount.LastName,
                                                              CountOfIsNotReadMessage = map.Messages.Where(x => x.IsRead == false && x.MessageMap.FromAccountID != id).Count(),
                                                              FromAccountID=map.FromAccountID,
                                                              LastMessageDate=map.LastMessageDate
                                                              //FromAccountID = map.FromAccountID,
                                                              //ToAccountID = map.ToAccountID
                                                          };
                return messageMaps.ToList();

            }
        }
    }
}
