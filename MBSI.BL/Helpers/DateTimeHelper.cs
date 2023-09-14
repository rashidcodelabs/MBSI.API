using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSI.BL.Helpers
{
    public class DateTimeHelper
    {
        #region Date Functions
        public static DateTime GetDate()
        {
            return DateTime.Now;
        }

        public static DateTime GetUTCDate()
        {
            return DateTime.UtcNow;
        }
        #endregion
    }
}
