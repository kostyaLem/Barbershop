namespace Barbershop.UI.ViewModels;

public class SelectableItemModel<T>
{
    public bool IsSelected { get; set; }

    public T Value { get; }

    public SelectableItemModel(T value)
    {
        Value = value;
    }

    public override string ToString()
        => Value?.ToString() ?? string.Empty;
}
