using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AvaloniaApplication1.Views;

public partial class MyWindow : Window
{
    public MyWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void Button_OnClick_Ok(object? sender, RoutedEventArgs e)
    {
        Close("Ok clicked");
    }

    private void Button_OnClick_Cancel(object? sender, RoutedEventArgs e)
    {
        Close("Cancel clicked");
    }
}