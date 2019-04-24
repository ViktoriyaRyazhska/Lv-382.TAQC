using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Data
{
    public sealed class LifetimeRepository
    {
        public const string DEFAULT_TOKEN_LIFETIME = "300000";
        public const string LONG_TOKEN_LIFETIME = "800000";
        public const string TOKEN_LIFETIME_WITH_SPACE = "21 98";
        public const string TOKEN_LIFETIME_WITH_SUBTRACTION_SIGN = "-456789";

        private LifetimeRepository()
        {
        }

        public static Lifetime GetDefault()
        {
            return new Lifetime(DEFAULT_TOKEN_LIFETIME);
        }

        public static Lifetime GetLongTime()
        {
            return new Lifetime(LONG_TOKEN_LIFETIME);
        }

        public static Lifetime GetTimeWithSpace()
        {
            return new Lifetime(TOKEN_LIFETIME_WITH_SPACE);
        }
      
        public static Lifetime GetTimeWithSubtractionSign()
        {
            return new Lifetime(TOKEN_LIFETIME_WITH_SUBTRACTION_SIGN);
        }
    }
}
