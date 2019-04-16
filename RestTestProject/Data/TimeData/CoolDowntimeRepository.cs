using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Data
{
    public sealed class CoolDowntimeRepository
    {
        public const string DEFAULT_COOLDOWNTIME = "180000";
        public const string LONG_COOLDOWNTIME = "400000";

        private CoolDowntimeRepository()
        {
        }

        public static CoolDowntime GetDefault()
        {
            return new CoolDowntime(DEFAULT_COOLDOWNTIME);
        }

        public static CoolDowntime GetLongTime()
        {
            return new CoolDowntime(LONG_COOLDOWNTIME);
        }
    }
}
