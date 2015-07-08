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
    (function() {{
        'use strict';
        var elements = document.querySelectorAll('[data-aspnet-browser-locale]');
        for (var i = 0; i < elements.length; i++) {{
            var element = elements[i];
            var msString = element.dataset.aspnetBrowserLocale;
            if (msString) {{
                var jsDate = new Date(parseInt(msString, 10));
                element.innerHTML = jsDate.toLocaleString();
            }}
            else {{
                element.innerHTML = '{0}';
            }}
        }}
    }})();
</script>",
NullValueDisplay));
        }

        public static MvcHtmlString LocaleDateTime(this HtmlHelper htmlHelper, DateTime? dateTime)
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