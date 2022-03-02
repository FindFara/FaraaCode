using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.Utilities.Extensions
{
    public  static class DataTimeExtension
    {
        public static string ToShamsi(this DateTime dateTime)
        {
            PersianCalendar p = new PersianCalendar();
            return p.GetYear(dateTime).ToString("0000") + "/" +
                    p.GetMonth(dateTime).ToString("00") + "/" +
                    p.GetDayOfMonth(dateTime).ToString("00");
        }
    }
}
