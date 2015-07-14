using System;
using System.Web.Mvc;

namespace RimDev.AspNetBrowserLocale
{
    public static class HtmlHelpers
    {
        private const string NullValueDisplay = "&mdash;";
        private const BrowserDateDisplay DefaultBrowserDateDisplay = BrowserDateDisplay.DateTime;

        private static readonly string DefaultMomentFormat =
            BrowserDateDisplayConverter.ToMomentJsFormat(DefaultBrowserDateDisplay);

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
                var momentFormat = element.dataset.aspnetBrowserLocaleMomentjsFormat || '{0}';

                element.innerHTML = m.format(momentFormat);
                element.setAttribute('title', m.format('LLLL'));
            }}
            else {{
                element.innerHTML = '{1}';
            }}
        }}
    }})();
</script>",
DefaultMomentFormat,
NullValueDisplay));
        }

        public static MvcHtmlString BrowserDisplay(
            this HtmlHelper htmlHelper,
            DateTime? dateTime,
            BrowserDateDisplay browserDateDisplay = DefaultBrowserDateDisplay)
        {
            long? msSinceUnixEpoch = null;
            if (dateTime.HasValue)
            {
                msSinceUnixEpoch = (long)((TimeSpan)(dateTime.Value.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds;
            }

            var momentFormat = BrowserDateDisplayConverter.ToMomentJsFormat(browserDateDisplay);

            return MvcHtmlString.Create(string.Format(
                @"<span data-aspnet-browser-locale=""{0}"" data-aspnet-browser-locale-momentjs-format=""{1}"">{2}</span>",
                msSinceUnixEpoch,
                momentFormat,
                dateTime.HasValue ? dateTime.Value.ToUniversalTime().ToString() + " UTC" : NullValueDisplay));
        }
    }
}