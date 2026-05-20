using DoomPacker.Backend;
using DoomPacker.Model;
using HandyControl.Controls;
using HandyControl.Tools.Command;
using HandyControl.Tools.Extension;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DoomPacker.ViewModel.Windows
{
    public class ModPackCreationWindowViewModel : INotifyPropertyChanged
    {
        // Services
        private FileManager fileManager = new();
        private PackService packService = new();

        // Events
        public ICommand FolderDoubleClickCommand { get; }
        public ICommand PackDoubldeClickCommand { get; }
        public ICommand SaveClickCommand { get; }

        // Modpack Info
        private string _imagePath;
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
            PackDoubldeClickCommand = new RelayCommand<object>(OnDoubleClickPack);
            SaveClickCommand = new RelayCommand<object>(OnSaveButton_Click);

            ModsInFolder = new(fileManager.FindModsInDirectory());
            ModsInModPack = [];
        }

        public object SelectedItemFolder
        {
            get => _selectedItemFolder;
            set
            {
                _selectedItemFolder = value;
                OnPropertyChanged();
            }
        }

        public object SelectedItemPack
        {
            get => _selectedItemPack;
            set
            {
                _selectedItemPack = value;
                OnPropertyChanged();
            }
        }

        private void OnDoubleClickFolder(object parameter)
        {
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

        public string ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public string Desctiption
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private void OnSaveButton_Click(object parameter)
        {
            SaveModpack(ImagePath, Title, Desctiption, ModsInModPack);
        }

        private ModPackContent SaveModpack(string ImagePath, string Title, string Description, ObservableCollection<string> Mods)
        {
            ModPackContent modPackContent = new()
            {
                Image = ImagePath,
                Title = Title,
                Description = Description,
                ModsOrder = Mods.ToList()
            };

            return modPackContent;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
