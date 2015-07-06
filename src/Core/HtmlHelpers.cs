using System;
using System.Web.Mvc;

namespace AspNetBrowserLocale.Core
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString InitializeLocaleDateTime(this HtmlHelper htmlHelper)
        {
            return MvcHtmlString.Create(
@"<script>
    var elements = document.querySelectorAll('[data-aspnet-browser-locale]');
    for (var i = 0; i < elements.length; i++) {{
        var element = elements[i];
        var msString = element.dataset.aspnetBrowserLocale;
        if (msString) {{
            var jsDate = new Date(parseInt(msString));
            element.innerHTML = jsDate.toLocaleString();
        }}
        else {{
            element.innerHTML = '&mdash;';
        }}
    }}
</script>");
        }

        public static MvcHtmlString LocaleDateTime(this HtmlHelper htmlHelper, DateTime? dateTime)
        {
            long? msSinceUnixEpoch = null;
            if (dateTime.HasValue)
            {
                msSinceUnixEpoch = (long)((TimeSpan)(dateTime.Value.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds;
            }

            return MvcHtmlString.Create(string.Format(
                @"<span data-aspnet-browser-locale=""{0}""></span>",
                msSinceUnixEpoch));
        }
    }
}