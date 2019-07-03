using AutoMapper;
using DiaryShare.BLL.Abstract;
using DiaryShare.Entities.ComplexTypes;
using DiaryShare.Entities.Concrete;
using DiaryShare.MVCWebUI.Dtos;
using DiaryShare.MVCWebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DiaryShare.MVCWebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageMapService _messageMapService;
        private readonly IAccountService _accountService;
        private readonly IMessageService _messageService;

        public MessageController(IMessageMapService messageMapService,
            IAccountService accountService,
            IMessageService messageService)
        {
            _messageMapService = messageMapService;
            _accountService = accountService;
            _messageService = messageService;
        }

        public ActionResult MessagingPage(int id=0)
        {
            int ownID = (int)Session["userID"];

            if (id != 0 || id != ownID)
            {
                if (_messageMapService.GetMap(ownID, id) == null)
                {
                    _messageMapService.Add(new MessageMap { FromAccountID = ownID, LastMessageDate = DateTime.Now, ToAccountID = id });
                    MessageMap updateMessageMap = _messageMapService.GetMap(id, ownID);
                    if (updateMessageMap != null)
                    {
                        updateMessageMap.LastMessageDate = DateTime.Now;
                        _messageMapService.Update(updateMessageMap);
                    }
                }
            }

            List<MessagePageData> messageMaps = _messageMapService.GetMessages(ownID);

            for (int i = 0; i < messageMaps.Count; i++)
            {
                int otherAccountID = messageMaps[i].AccountID;
                if (messageMaps.Where(x => x.AccountID == otherAccountID).ToList().Count > 1 && messageMaps[i].FromAccountID == ownID)
                {
                    messageMaps.Remove(messageMaps[i]);
                }
            }

            return View(new MessagePageViewModel { AccountsOfMessages = messageMaps.OrderByDescending(x => x.LastMessageDate).ToList(), MainAccountID = (int)Session["userID"] });
        }

        [HttpPost]
        public JsonResult RequestMessagingContent(int id)
        {
            int ownID = (int)Session["userID"];

            List<MessageForMessageContentDto> messages = Mapper.Map<List<MessageForMessageContentDto>>(_messageService.GetMessages(ownID, id));

            return Json(messages, JsonRequestBehavior.AllowGet);
        }
    }
}

    
