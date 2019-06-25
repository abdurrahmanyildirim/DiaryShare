using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiaryShare.MVCWebUI.Dtos
{
    public class AccountForProfileDto: AccountBaseDto
    {
        public int AccountID { get; set; }
        public string PersonelInfo { get; set; }
        public DateTime MemberDate { get; set; }
    }
}