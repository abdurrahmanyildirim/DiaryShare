using DiaryShare.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.Entities.ComplexTypes
{
    public class MessagePageData
    {
        public int AccountID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int CountOfIsNotReadMessage { get; set; }
        public int FromAccountID { get; set; }
        public DateTime LastMessageDate { get; set; }
    }
}
