using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApi.Model
{
    public partial class ResponseModel
    {
        public ResponseModel(User user)
        {
            
            UserName = user.UserName;
            Passwod = user.Passwod;
            Id = user.Id;
            Name = user.Name;
        
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Passwod { get; set; }
    }
}