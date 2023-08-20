﻿using System.Linq.Expressions;
using Chat.Service.Domain.Chats.Aggregates;

namespace Chat.Service.Domain.Chats.Repositories;

public interface IChatGroupInUserRepository : IRepository<ChatGroupInUser,Guid>
{
    Task<IEnumerable<ChatGroup>> GetUserChatGroupAsync(Guid userId);

    /// <summary>
    /// 获取群组中的用户。
    /// </summary>
    /// <param name="groupId"></param>
    /// <returns></returns>
    Task<List<ChatGroupInUser>> GetGroupInUserAsync(Guid groupId);
}