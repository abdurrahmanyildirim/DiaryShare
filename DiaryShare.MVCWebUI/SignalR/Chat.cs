using System;
using System.Collections.Generic;
using AutoMapper;
using DiaryShare.BLL.Abstract;
using DiaryShare.BLL.DependencyResolvers.Ninject;
using DiaryShare.Entities.Concrete;
using DiaryShare.MVCWebUI.Dtos;
using Microsoft.AspNet.SignalR;

namespace DiaryShare.MVCWebUI
{
    public class Chat : Hub
    {
        private readonly IMessageService _messageService;
        private readonly IMessageMapService _messageMapService;

        public Chat() : base()
        {
            _messageMapService = InstanceFactory.GetInstance<IMessageMapService>();
            _messageService = InstanceFactory.GetInstance<IMessageService>();
        }

        public void SendMessage(string message, int targetID, int ownID)
        {
            MessageMap messageMap = _messageMapService.GetMap(ownID, targetID);
            messageMap.LastMessageDate = DateTime.Now;
            _messageMapService.Update(messageMap);

            MessageMap targetMessageMap = _messageMapService.GetMap(targetID, ownID);

            targetMessageMap.LastMessageDate = DateTime.Now;
            _messageMapService.Update(targetMessageMap);

            _messageService.Add(new Message
            {
                IsActive = true,
                IsRead = false,
                MessageContent = message,
                MessageMapID = messageMap.MessageMapID,
                SendDate = DateTime.Now
            });

            Clients.All.addMessage(message, targetID, ownID);
        }

        public void LoadMessages(int ownID, int targetID)
        {
            List<MessageForMessageContentDto> messages = Mapper.Map<List<MessageForMessageContentDto>>(_messageService.GetMessages(ownID, targetID));
            Clients.All.loadMessagingContent(messages, ownID);
        }

        public void UpdateMessage(int ownID, int targetID)
        {
            _messageService.ChangeIsReadOfMessage(ownID, targetID);
            Clients.All.updateFunction();
        }

        //public void Update(int targetID)
        //{
        //    List<MessagePageData> messageMaps = _messageMapService.GetMessages(targetID);

        //    for (int i = 0; i < messageMaps.Count; i++)
        //    {
        //        int otherAccountID = messageMaps[i].AccountID;
        //        if (messageMaps.Where(x => x.AccountID == otherAccountID).ToList().Count > 1 && messageMaps[i].FromAccountID == targetID)
        //        {
        //            messageMaps.Remove(messageMaps[i]);
        //        }
        //    }

        //    Clients.All.updateMessageMaps(messageMaps.OrderByDescending(x => x.LastMessageDate).ToList(), targetID);
        //}
    }
}