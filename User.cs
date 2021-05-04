using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork10_ado
{
    public class User
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public string mail { get; set; }
        public DateTime dateDay { get; set; }
        public byte[] imageData { get; set; }
        public UserLogInfo userLogInfo { get; set; }

        public User(string name, string lastName, string mail, DateTime dateDay, byte[] imageData, UserLogInfo userLogInfo)
        {
            this.name = name;
            this.lastName = lastName;
            this.mail = mail;
            this.dateDay = dateDay;
            this.imageData = imageData;
            this.userLogInfo = userLogInfo;
        }
    }
}
