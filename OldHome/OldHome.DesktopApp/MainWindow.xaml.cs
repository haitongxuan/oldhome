using OldHome.DesktopApp.ViewModels;
using Panuon.WPF.UI;
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

namespace OldHome.DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : WindowX
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                var vm = (MainWindowViewModel)DataContext;
                var cmd = vm.LoadedCommand;
                cmd?.Execute(null);
            };
        }
    }
}