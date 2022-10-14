using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApi.Models
{
    public partial class ChatRoom
        
    {
        public string GetLastMessage 
        {
        get
            {
                string message = "Нет";
                try
                {
                    message = ChatMessage.LastOrDefault()?.TestMessage ?? "Нет сообщений";
                    return message;
                }
                catch
                {
                    return message;
                }
            }
        }
    }
}