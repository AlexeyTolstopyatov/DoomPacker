namespace DoomPacker.Model;

public class ModPackInfo : ModContainer
{
    // Поскольку вы наследуете ModContainer, то вы автоматически подтягиваете все protected 
    // методы и поля этого класса. Поэтому теперь о OnPropertyChanged не надо. 
    private string? _description;
    
    public string? Description
    {
        get => _description;
        set => SetField(ref _description, value);
    }
}