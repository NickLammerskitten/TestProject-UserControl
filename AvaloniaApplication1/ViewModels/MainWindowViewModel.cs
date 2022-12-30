using System.Reactive.Linq;
using System.Windows.Input;
using AvaloniaApplication1.Views;
using ReactiveUI;

namespace AvaloniaApplication1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _contentSecondView;
        public MainWindowViewModel()
        {
            ContentSecondView = SecondView = new SecondViewModel();
        }
        
        public ViewModelBase ContentSecondView
        {
            get => _contentSecondView;
            private set => this.RaiseAndSetIfChanged(ref _contentSecondView, value);
        }

        public static SecondViewModel SecondView { get; set; }
    }
}