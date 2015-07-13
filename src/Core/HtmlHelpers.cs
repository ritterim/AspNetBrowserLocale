using System;
using System.Web.Mvc;

namespace AspNetBrowserLocale.Core
{
    public static class HtmlHelpers
    {
        private const string NullValueDisplay = "&mdash;";

        public static MvcHtmlString InitializeLocaleDateTime(this HtmlHelper htmlHelper)
        {
            return MvcHtmlString.Create(string.Format(
@"<script>
if (typeof moment === 'undefined') {{
    document.write(unescape(""%3Cscript src='https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.3/moment.min.js'%3E%3C/script%3E""));
}}
</script>
<script>
    (function() {{
        'use strict';
        var elements = document.querySelectorAll('[data-aspnet-browser-locale]');
        for (var i = 0; i < elements.length; i++) {{
            var element = elements[i];
            var msString = element.dataset.aspnetBrowserLocale;
            if (msString) {{
                var m = moment(parseInt(msString, 10));
                element.innerHTML = m.format('l LT');
            }}
            else {{
                element.innerHTML = '{0}';
            }}
        }}
    }})();
</script>",
NullValueDisplay));
        }

        public static MvcHtmlString BrowserDisplay(this HtmlHelper htmlHelper, DateTime? dateTime)
        {
            long? msSinceUnixEpoch = null;
            if (dateTime.HasValue)
            {
                msSinceUnixEpoch = (long)((TimeSpan)(dateTime.Value.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds;
            }

            return MvcHtmlString.Create(string.Format(
                @"<span data-aspnet-browser-locale=""{0}"">{1}</span>",
                msSinceUnixEpoch,
                dateTime.HasValue ? dateTime.Value.ToUniversalTime().ToString() + " UTC" : NullValueDisplay));
        }
    }
}