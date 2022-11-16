using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visit.Commodity.Calculation.Common.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public static class DateFormatHandler
    {

        /// <summary>
        /// Gets the UTC time stamp.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static int GetUTCTimeStamp(DateTime dateTime)
        {
            Int32 unixTimestamp = (int)dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            return unixTimestamp;
        }

    }
}
