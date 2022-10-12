namespace HumarResource.Application.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime? ToDate(this string probDate)
        {
            if (!string.IsNullOrWhiteSpace(probDate))
            {
                DateTime converted;
                if (DateTime.TryParse(probDate, out converted))
                {
                    return converted;
                }
            }
            return null;
        }
    }
}
