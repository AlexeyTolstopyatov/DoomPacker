using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DoomPacker.Model
{
    public class ModPackContent : ModPackInfo, INotifyPropertyChanged
    {
        private string? _description;
        private List<string> _modsOrder;

        public string Description
        {
            get { return _description; }
            set 
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public List<string> ModsOrder
        {
            get { return _modsOrder; }
            set
            {
                _modsOrder = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
