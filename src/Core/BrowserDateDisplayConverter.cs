using System;

namespace AspNetBrowserLocale.Core
{
    public class BrowserDateDisplayConverter
    {
        public static string ToMomentJsFormat(BrowserDateDisplay browserDateDisplay)
        {
            switch (browserDateDisplay)
            {
                case BrowserDateDisplay.DateTime:
                    return "l LT";

                case BrowserDateDisplay.DateOnly:
                    return "l";

                case BrowserDateDisplay.TimeOnly:
                    return "LT";

                default:
                    throw new ArgumentException("browserDateDisplay value is not supported.");
            }
        }
    }
}