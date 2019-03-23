using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.TestsData
{
    public class ActionMessages
    {
        public string Message { get; private set; } 

        public ActionMessages(string messageText)
        {
            Message = messageText;
        }
    }
}
