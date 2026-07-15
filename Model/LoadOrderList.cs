using System.Collections.ObjectModel;

namespace DoomPacker.Model;

public class LoadOrderList : ModContainer
{
    public ObservableCollection<string>? Mods { get; private set; }
}