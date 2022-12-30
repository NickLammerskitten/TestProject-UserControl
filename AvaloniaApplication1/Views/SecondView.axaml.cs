using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
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

        var result = await dialog.ShowDialog<SecondViewModel?>(new MainWindow());
                // Error of this: Argument type 'AvaloniaApplication1.Views.SecondView' is not assignable to parameter type 'Avalonia.Controls.Window'
        interaction.SetOutput(result);
    }
}