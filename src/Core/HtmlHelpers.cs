using System;
using System.Web.Mvc;

namespace AspNetBrowserLocale.Core
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString LocaleDateTime(this HtmlHelper htmlHelper, DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                var elementId = Guid.NewGuid();
                var msSinceUnixEpoch = (long)((TimeSpan)(dateTime.Value.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds;

                return MvcHtmlString.Create(string.Format(
@"<span id=""aspnet-browser-locale-{0}""></span>
<script>
    var jsDate = new Date({1});
    document.getElementById('aspnet-browser-locale-{0}').innerHTML = jsDate.toLocaleString();
</script>",
elementId,
msSinceUnixEpoch));
            }
            else
            {
                return MvcHtmlString.Create("&mdash;");
            }
        }
    }
}