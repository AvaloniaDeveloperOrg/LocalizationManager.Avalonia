using Avalonia;
using Avalonia.Controls;
using System.Globalization;

namespace LocalizationManager.Sample.Views;
public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        _localizationManager = LocalizationManagerExtensions.Default!;
        PART_Button.Click += PART_Button_Click;
    }

    readonly ILocalizationManager _localizationManager;

    private void PART_Button_Click(object? sender, global::Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_localizationManager.CurrentCulture.TwoLetterISOLanguageName == "en")
            _localizationManager.CurrentCulture = new CultureInfo("zh");
        else
            _localizationManager.CurrentCulture = new CultureInfo("en");
    }
}