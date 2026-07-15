// CoffeeLake (C) 2026-*
// 
// The NotifyPropertyChanged.cs represents <what?>
// 
// @local_machine: atvlg
// @creator: atolstopyatov2017@vk.com

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DoomPacker;
/// <summary>
/// Основа основ для внезапно обновляющихся объектов.
/// Все, что здесь нужно это SetField(ref _полеИзViewModel, значение). 
/// </summary>
public class NotifyPropertyChanged : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}