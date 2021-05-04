using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork10_ado
{
    public class UserLogInfo
    {
        public string nickName { get; set; }
        public int password { get; set; }

        public UserLogInfo(string nickName, int password)
        {
            this.nickName = nickName;
            this.password = password;
        }
    }
}
