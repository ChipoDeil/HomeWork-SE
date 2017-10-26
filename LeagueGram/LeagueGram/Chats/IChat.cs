﻿using System;

namespace LeagueGram
{
    public interface IChat
    {
        Guid Id { get; }
        IMessage[] Messages { get; set; }
        IChatMember[] ChatMembers { get; set; }


        void SendMessage(IUser chatMember, string Message);

        void EditMessage(IUser chatMember, IMessage message, string newMessage);

        void DeleteMessage(IUser chatMember, IMessage message);

        void InviteUser(IUser inviter, IUser invitedPerson);

        void EditRoleOfChatMember(IUser editor, IUser editingPerson, ChatRole newRole);

    }
}