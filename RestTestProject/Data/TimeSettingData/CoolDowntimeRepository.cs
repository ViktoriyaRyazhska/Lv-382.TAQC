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
        public const string COOLDOWNTIME_WITH_SPACE = "21 98";
        public const string COOLDOWNTIME_WITH_SUBTRACTION_SIGN = "-456789";

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

        public static CoolDowntime GetTimeWithSpace()
        {
            return new CoolDowntime(COOLDOWNTIME_WITH_SPACE);
        }

        public static CoolDowntime GetTimeWithSubtractionSign()
        {
            return new CoolDowntime(COOLDOWNTIME_WITH_SUBTRACTION_SIGN);
        }
    }
}
