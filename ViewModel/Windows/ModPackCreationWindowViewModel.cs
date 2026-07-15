using DoomPacker.Backend;
using HandyControl.Tools.Command;
using HandyControl.Tools.Extension;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DoomPacker.ViewModel.Windows
{
    public class ModPackCreationWindowViewModel : NotifyPropertyChanged
    {
        // Services
        private FileManager _fileManager = new();
        private PackService _packService = new();

        // Events
        public ICommand FolderDoubleClickCommand { get; }
        public ICommand PackDoubleClickCommand { get; }
        public ICommand SaveClickCommand { get; }
        public ICommand RememberImagePathCommand { get; }
        public ICommand ViewModelStateCommand { get; }

        // Modpack Info
        private Uri? _imagePath;
        private string _title;
        private string _description;

        // Mods lists
        private object _selectedItemFolder;
        private object _selectedItemPack;
        public ObservableCollection<string> ModsInFolder { get; set; }
        public ObservableCollection<string> ModsInModPack { get; set; }


        public ModPackCreationWindowViewModel()
        {
            FolderDoubleClickCommand = new RelayCommand<object>(OnDoubleClickFolder);
            PackDoubleClickCommand = new RelayCommand<object>(OnDoubleClickPack);
            SaveClickCommand = new RelayCommand<object>(SaveModpack);
            RememberImagePathCommand = new RelayCommand<Uri>(RememberImagePath);
            ViewModelStateCommand = new RelayCommand(ViewModelState);
            
            ModsInFolder = new ObservableCollection<string>(_fileManager.FindModsInDirectory());
            ModsInModPack = [];
        }

        public object SelectedItemFolder
        {
            get => _selectedItemFolder;
            set => SetField(ref _selectedItemFolder, value);
        }

        public object SelectedItemPack
        {
            get => _selectedItemPack;
            set => SetField(ref _selectedItemPack, value);
        }

        private void ViewModelState(object _)
        {
            Console.WriteLine(@$"At the moment of saving:
Title: {Title}
Description: {Description}

Preview Image: {ImagePath?.AbsolutePath ?? "what"}
Mods (in folder): {ModsInFolder.Count}
Mods (in pack): {ModsInModPack.Count}
");
        }
        
        private void OnDoubleClickFolder(object parameter)
        {
            // Че это такое...
            var item = parameter ?? SelectedItemFolder;

            ModsInFolder.DeleteIfExists(item.ToString());
            ModsInModPack.Add(item.ToString());
        }

        private void OnDoubleClickPack(object parameter)
        {
            var item = parameter ?? SelectedItemPack;

            ModsInModPack.DeleteIfExists(item.ToString());
            ModsInFolder.Add(item.ToString());
        }

        public Uri? ImagePath
        {
            get => _imagePath;
            set => SetField(ref _imagePath, value);
        }

        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }

        public string Description
        {
            get => _description;
            set => SetField(ref _description, value);
        }

        private void RememberImagePath(Uri? parameter)
        {
            if (parameter is not null)
            {
                ImagePath = parameter;
            }
            else
            {
                Console.WriteLine("parameter is null");
            }
            // А если вдруг null то вы уже сами думайте надо ли тут что-то делать
        }

        private void SaveModpack(object parameter)
        {
            // ModPackContent modPackContent = new()
            // {
            //     Image = ImagePath,
            //     Title = Title,
            //     Description = Description,
            //     ModsOrder = Mods
            // };
        }
    }
}
