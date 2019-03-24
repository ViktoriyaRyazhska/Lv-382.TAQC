using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.TestsData
{
    public class ActionMessages
    {
        private string Message { get; set; } 

        public ActionMessages(string messageText)
        {
            Message = messageText;
        }
        public string GetMessage()
        {
            return Message;
        }
    }
}
