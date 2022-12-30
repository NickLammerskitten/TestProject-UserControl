using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Avalonia.Threading;
using AvaloniaApplication1.ViewModels;
using ReactiveUI;

namespace AvaloniaApplication1.Views;

public partial class SecondView : ReactiveUserControl<SecondViewModel>
{
    public SecondView()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    private async Task DoShowDialogAsync(InteractionContext<MyWindowViewModel, SecondViewModel?> interaction)
    {
        var dialog = new MyWindow();
        dialog.DataContext = interaction.Input;

        var result = await dialog.ShowDialog<SecondViewModel?>(App.MainWindow);
        interaction.SetOutput(result);
    }
}