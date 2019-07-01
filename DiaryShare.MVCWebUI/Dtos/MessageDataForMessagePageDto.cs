using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiaryShare.MVCWebUI.Dtos
{
    public class MessageDataForMessagePageDto
    {
        public MessageDataForMessagePageDto()
        {
            Messages = new List<MessageForMessageContentDto>();
        }
        public int AccountID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<MessageForMessageContentDto> Messages { get; set; }
    }
}