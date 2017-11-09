using Newtonsoft.Json.Converters;

namespace ModulbankClient
{
    internal class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
