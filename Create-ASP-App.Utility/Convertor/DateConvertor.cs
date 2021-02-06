using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Create_ASP_App.Utility.Convertor
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(date) + "/" + pc.GetMonth(date).ToString("00") + "/" +
                   pc.GetDayOfMonth(date).ToString("00");
        }

        // Convert Persian DateTime with Format 1399/10/26 to miladi dateTime
        public static DateTime ToMiladi(this string date)
        {
            string date2 = Regex.Replace(date, "[۰-۹]", x => ((char)(x.Value[0] - '۰' + '0')).ToString());

            DateTime dt = DateTime.ParseExact(date2, "yyyy/MM/dd", CultureInfo.InvariantCulture);

            PersianCalendar pc = new PersianCalendar();
            DateTime dt2 = pc.ToDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);

            return dt2;
        }

    }
}
