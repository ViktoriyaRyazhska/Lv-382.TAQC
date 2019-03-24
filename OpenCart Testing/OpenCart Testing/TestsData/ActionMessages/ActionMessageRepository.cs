using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.TestsData
{
    public sealed class ActionMessageRepository
    {
        private volatile static ActionMessageRepository instance;
        private static object lockingObject = new object();

        private ActionMessageRepository()
        {
        }

        public static ActionMessageRepository Get()
        {
            if (instance == null)  //
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new ActionMessageRepository();
                    }
                }
            }
            return instance;
        }

        public ActionMessages TooShortNameReviewMessage()
        {
            return new ActionMessages("Warning: Review Name must be between 3 and 25 characters!");
        }
    }
}
