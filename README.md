# AspNetBrowserLocale

Provides functionality for showing DateTime information respecting the time zone of the users browser using Razor.

![NuGet Version](https://img.shields.io/nuget/v/RimDev.AspNetBrowserLocale.svg)
![NuGet Download Count](https://img.shields.io/nuget/dt/RimDev.AspNetBrowserLocale.svg)

## Usage (Razor)

In **_Layout.cshtml** or a similar file, add the following:

```
@using RimDev.AspNetBrowserLocale

@Html.InitializeLocaleDateTime()
```

Then, for each DateTime (or, nullable DateTime) value you wish to display:

```
@using RimDev.AspNetBrowserLocale
@{
    var myDateTime = new DateTime(2015, 1, 1);
}

@Html.BrowserDisplay(myDateTime)
```

## License

MIT
