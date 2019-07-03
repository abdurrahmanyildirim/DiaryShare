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
            
            if (_messageMapService.GetMap(ownID, targetID) == null)
            {
                _messageMapService.Add(new MessageMap { FromAccountID = ownID, LastMessageDate = DateTime.Now, ToAccountID = targetID });
                MessageMap updateMessageMap = _messageMapService.GetMap(targetID, ownID);
                if (updateMessageMap != null)
                {
                    updateMessageMap.LastMessageDate = DateTime.Now;
                    _messageMapService.Update(updateMessageMap);
                }
            }

            MessageMap messageMap = _messageMapService.GetMap(ownID, targetID);

            _messageService.Add(new Message
            {
                IsActive = true,
                IsRead = false,
                MessageContent = message,
                MessageMapID = messageMap.MessageMapID,
                SendDate = DateTime.Now
            });

            Clients.All.addMessage(message, targetID,ownID);
        }

        public void LoadMessages(int ownID,int targetID)
        {
            List<MessageForMessageContentDto> messages = Mapper.Map<List<MessageForMessageContentDto>>(_messageService.GetMessages(ownID, targetID));
            Clients.All.loadMessagingContent(messages,ownID);
        }

        public void Update(string message, int targetID, int ownID)
        {

            Clients.All.addMessage(message, ownID);
        }
    }
}