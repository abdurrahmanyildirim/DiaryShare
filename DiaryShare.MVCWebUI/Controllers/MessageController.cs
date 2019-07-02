using AutoMapper;
using DiaryShare.BLL.Abstract;
using DiaryShare.Entities.ComplexTypes;
using DiaryShare.Entities.Concrete;
using DiaryShare.MVCWebUI.Dtos;
using DiaryShare.MVCWebUI.ViewModels;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public ActionResult MessagingPage()
        {
            int ownID = (int)Session["userID"];

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

        //public class Chat : Hub
        //{
        //    //private readonly IMessageService _messageService;
        //    //private readonly IMessageMapService _messageMapService;

        //    //public Chat(IMessageMapService messageMapService,
        //    //    IMessageService messageService)
        //    //{
        //    //    _messageMapService = messageMapService;
        //    //    _messageService = messageService;
        //    //}

        //    public void SendMessage(string message, int targetID, int ownID)
        //    {
        //        //if (_messageMapService.GetMap(ownID, targetID) == null)
        //        //{
        //        //    _messageMapService.Add(new MessageMap { FromAccountID = ownID, LastMessageDate = DateTime.Now, ToAccountID = targetID });
        //        //    MessageMap updateMessageMap = _messageMapService.GetMap(targetID, ownID);
        //        //    if (updateMessageMap != null)
        //        //    {
        //        //        updateMessageMap.LastMessageDate = DateTime.Now;
        //        //        _messageMapService.Update(updateMessageMap);
        //        //    }
        //        //}

        //        //MessageMap messageMap = _messageMapService.GetMap(ownID, targetID);

        //        //_messageService.Add(new Message
        //        //{
        //        //    IsActive = true,
        //        //    IsRead = false,
        //        //    MessageContent = message,
        //        //    MessageMapID = messageMap.MessageMapID,
        //        //    SendDate = DateTime.Now
        //        //});

        //        Clients.All.addMessage(message, ownID);
        //    }
    }
}

    
