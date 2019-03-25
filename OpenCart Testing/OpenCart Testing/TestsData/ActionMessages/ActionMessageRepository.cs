using OpenCart_Testing.Tools;

namespace OpenCart_Testing.TestsData
{
    public sealed class ActionMessageRepository
    {
        private volatile static ActionMessageRepository instance;
        private static object lockingObject = new object();
        private static string directory = "ActionMessages";

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

        public ActionMessage TooShortNameReviewMessage()
        {
            return new ActionMessage("Warning: Review Name must be between 3 and 25 characters!");
        }
        public ActionMessage TooLongReviewMessage()
        {
            return new ActionMessage("Warning: Review Name must be between 3 and 25 characters!");
        }

        public ActionMessage ActionMessageFromJson(string filename)
        {
            return JsonParser.DeserializeFromFile<ActionMessage>(directory, filename);
        }

    }
}
