using DoomPacker.ViewModel.Windows;

namespace DoomPacker.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для ModPackCreationWindow.xaml
    /// </summary>
    public partial class ModPackCreationWindow : HandyControl.Controls.Window
    {
        public ModPackCreationWindow()
        {
            InitializeComponent();

            DataContext = new ModPackCreationWindowViewModel();
        }
    }
}
