using System.Globalization;

namespace WebSystem.Helpers
{
    public class CustomFormats
    {
        public static string CustomDateFormat(string dateToFormat)
        {
            string[] validformats = new string[] { "MM/dd/yyyy HH:mm:ss" };
            CultureInfo provider = new CultureInfo("en-US");
            var newDateTime = DateTime.ParseExact(dateToFormat, validformats, provider);

            return newDateTime.ToString("yyyy-MM-dd hh:mm");
        }
    }
}
