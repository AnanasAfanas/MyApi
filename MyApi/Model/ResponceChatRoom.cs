using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApi.Model
{
    public class ResponceChatRoom
    {
        public ResponceChatRoom(ChatRoom chatRoom)
        {
            
            Topic = chatRoom.Topic;
            LastMessage = chatRoom.GetLastMessage;
        }
        public int Id { get; set; }
        public string Topic { get; set; }
        public string LastMessage { get; set; }
    }
}