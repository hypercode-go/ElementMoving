using ReactiveUI;

using System.Reactive.Disposables;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReactiveMarbles.ObservableEvents;
using System.Reactive.Linq;
using System.Reactive;
namespace ElementMoving
{

    public partial class MainWindow : Window, IViewFor<MainWindowViewModel>
    {
        public MainWindowViewModel? ViewModel { get; set; }

        object? IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MainWindowViewModel?)value;
        }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainWindowViewModel();
            this.DataContext = ViewModel;
            this.WhenActivated(disposable =>
            {
                this.Bind(ViewModel, vm => vm.Title, view => view.Description.Text).DisposeWith(disposable);
                //this.Events()
                //.MouseLeftButtonDown
                //.Select(args => Unit.Default)
                //.InvokeCommand(this, x => x.ViewModel.MyCommand).DisposeWith(disposable);
            });
        }
    }
}