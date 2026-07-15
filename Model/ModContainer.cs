// CoffeeLake (C) 2026-*
// 
// The ModContainer.cs represents <what?>
// 
// @local_machine: atvlg
// @creator: atolstopyatov2017@vk.com

namespace DoomPacker.Model;

/// <summary>
/// Где-то в коде или в XAML дизайнере вы можете попробовать
/// опираться на это. У любого уважающего себя ModContainer производного
/// будет пометка о том кто он на самом деле.
/// Тогда легким движением руки вы превратите ModContainer в ModPack
///
/// var pack = ModPack.Extend(modContainer);
/// Или если вы очень любите C++, то pack = (ModPack)modContainer
/// Но это не очень безопасно. Возможно вы получите по жопе из-за заполнения/выравнивания структур
///
/// Такой трюк прокатывает только если классы идентичны до какого-то места.
/// В месте где начинаются расхождения - будет или мусор (С++) или nullы. 
/// </summary>
public enum ModContainerType
{
    OrderList,
    Modpack
}
/// <summary>
/// Мне кажется этот тип лучше взять вместо Object, он как-то более конкретный
///
/// Во всяком случае он удобнее Object потому что Object не имеет того что вы хотите показать в окне.
///
/// Да и класс я отметил специально как абстрактный. Чтобы соблазна вызвать конструктор не было.
/// Это так называемая база. Которую нельзя менять нельзя создать и тд.
/// </summary>
public abstract class ModContainer : NotifyPropertyChanged
{
    private ModContainerType _type;
    
    private Uri? _imagePath = new(System.IO.Path.Combine(AppContext.BaseDirectory, App.AppSettings.PackIconPath));
    private string? _path;
    private string? _title;
    
    public ModContainerType Type 
    {
        get => _type;
        set => SetField(ref _type, value);
    }
    public Uri? ImagePath
    {
        get => _imagePath;
        set => SetField(ref _imagePath, value);
    }
    public string? Path
    {
        get => _path;
        set => SetField(ref _path, value);
    }
    
    public string? Title
    {
        get => _title;
        set => SetField(ref _title, value);
    }
}