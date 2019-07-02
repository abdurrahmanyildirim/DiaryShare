using DiaryShare.Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiaryShare.MVCWebUI.ViewModels
{
    public class MessagePageViewModel
    {
        public List<MessagePageData> AccountsOfMessages { get; set; }
        public int MainAccountID { get; internal set; }
    }
}