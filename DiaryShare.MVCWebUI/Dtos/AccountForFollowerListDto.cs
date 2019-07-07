using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiaryShare.MVCWebUI.Dtos
{
    public class AccountForFollowerListDto : AccountBaseDto
    {
        public string PersonelInfo { get; set; }
        public int AccountID { get; set; }
    }
}