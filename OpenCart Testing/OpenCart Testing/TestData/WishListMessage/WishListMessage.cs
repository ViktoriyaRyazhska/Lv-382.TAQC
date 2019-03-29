using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.TestData.WishListMessage
{
    public class WishListMessage
    {
        public string Message { get; set; }

        public WishListMessage(string messageText)
        {
            Message = messageText;
        }
        public string GetMessage()
        {
            return Message;
        }
    }
}
