using System.Windows;
using DoomPacker.View.Windows;
using DoomPacker.ViewModel.Windows;

namespace DoomPacker.View
{
    public partial class MainWindow : HandyControl.Controls.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ModPackCreationWindow creationWindow = new();
            creationWindow.Show();
        }
    }
}