using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.TestData
{
    public class ActionMessage
    {
        public string Message { get; set; } 

        public ActionMessage(string messageText)
        {
            Message = messageText;
        }
        public string GetMessage()
        {
            return Message;
        }
    }
}
