using System.Reactive.Linq;
using System.Windows.Input;
using ReactiveUI;

namespace AvaloniaApplication1.ViewModels;

public class SecondViewModel : ViewModelBase
{
    public SecondViewModel()
    {
        ShowDialog = new Interaction<MyWindowViewModel, SecondViewModel?>();
            
        OpenWindowCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var window = new MyWindowViewModel();

            var result = await ShowDialog.Handle(window);
        });
    }
    
    public Interaction<MyWindowViewModel, SecondViewModel?> ShowDialog { get; }
        
    public ICommand OpenWindowCommand { get; }
}