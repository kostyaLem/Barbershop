using DevExpress.Mvvm;

namespace Barbershop.UI.ViewModels;

public class SelectableItemModel<T> : BindableBase
{
    public bool IsSelected
    {
        get => GetValue<bool>(nameof(IsSelected));
        set => SetValue(value, nameof(IsSelected));
    }

    public T Value { get; }

    public SelectableItemModel(T value)
    {
        Value = value;
    }

    public override string ToString()
        => Value?.ToString() ?? string.Empty;
}
