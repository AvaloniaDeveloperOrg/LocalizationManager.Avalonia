﻿namespace LocalizationManager.Avalonia;

public class LocalizedXamlString : AvaloniaObject
{
    public LocalizedXamlString()
    {

    }

    public LocalizedXamlString(string token)
    {
        Token = token;
    }

    public LocalizedXamlString(string token, string format)
    {
        Token = token;
        StringFormat = format;
    }

    [Content]
    [MarkupExtensionDefaultOption]
    public string Token { get; set; } = string.Empty;

    public string? StringFormat { get; set; }

    protected BehaviorSubject<string>? Subject { get; private set; }

    public  object ProvideValue(IServiceProvider serviceProvider)
    {
        var LocalizationManager = AvaloniaLocator.Current.GetService<ILocalizationManager>();
        if (LocalizationManager is null)
            return AvaloniaProperty.UnsetValue;

        LocalizationManager.PropertyChanged += (s, e) =>
        {
            Subject?.OnNext(LocalizationManager[Token]);
        };

        Subject = new(LocalizationManager[Token]);

        var binding = new Binding
        {
            Mode = BindingMode.OneWay,
            Path = $"Subject^",
            Source = this,
            StringFormat = StringFormat
        };

        return binding;
    }
}
