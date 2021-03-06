﻿using DiaryShare.Entities.ComplexTypes;
using DiaryShare.Entities.Concrete;
using System.Collections.Generic;

namespace DiaryShare.BLL.Abstract
{
    public interface IMessageMapService
    {
        List<MessagePageData> GetMessages(int id);
        List<MessageMap> GetAccounts(int id);
        MessageMap GetMap(int ownID, int targetID);
        void Add(MessageMap messageMap);
        void Update(MessageMap messageMap);
    }
}