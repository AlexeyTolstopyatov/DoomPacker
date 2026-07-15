using System.Collections.ObjectModel;
using DoomPacker.Model;

namespace DoomPacker.ViewModel.Windows
{
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        private object _selectedModPack;
        public ObservableCollection<ModContainer> Collection { get; set; }

        public object SelectedModPack
        {
            get => _selectedModPack;
            set => SetField(ref _selectedModPack, value);
        }

        public MainWindowViewModel()
        {
            // Начиная с .net 5.0 все что вы обозначаете без знака ? не может содержать null.
            // Оно обязано быть инициализировано. 
            //
            // selectedModPack не инициализирован, => warning 
            // MainWindowViewModel конструктор не инициализирует _selectedModPack => warning
            Collection = 
            [
                new ModPackInfo { Title = "ModPack 1", Path = "Null" },
                new LoadOrderList { Title = "LoadOrderList", Path = "Null" }
            ];
            // никаких null
            _selectedModPack = Collection[0];
        }
    }
}
