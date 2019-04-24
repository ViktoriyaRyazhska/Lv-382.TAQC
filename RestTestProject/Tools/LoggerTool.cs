using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace RestTestProject.Tools
{
    public static class LoggerTool
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        public static void GetLogger()
        {
            switch (TestContext.CurrentContext.Result.Outcome.Status)
            {
                case TestStatus.Failed:
                    log.Error(TestContext.CurrentContext.Test.Name + TestStatus.Failed);
                    break;
                case TestStatus.Passed:
                    log.Info(TestContext.CurrentContext.Test.Name + TestStatus.Passed);
                    break;
                case TestStatus.Inconclusive:
                    log.Info(TestContext.CurrentContext.Test.Name + TestStatus.Inconclusive);
                    break;
                case TestStatus.Skipped:
                    log.Info(TestContext.CurrentContext.Test.Name + TestStatus.Skipped);
                    break;
                case TestStatus.Warning:
                    log.Warn(TestContext.CurrentContext.Test.Name + TestStatus.Warning);
                    break;
            }
        }
    }
}
