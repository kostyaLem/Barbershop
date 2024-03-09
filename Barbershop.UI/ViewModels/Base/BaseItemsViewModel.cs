using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using HandyControl.Tools.Extension;

namespace Barbershop.UI.ViewModels.Base;

/// <summary>
/// Базовый класс для всех ViewModel'ей.
/// Имеется флаг IsUploading для отображения индикатора загрузки, используя метод Execute
/// </summary>
public abstract class BaseItemsViewModel<T> : BaseViewModel
{
    protected readonly ObservableCollection<T> _items;

    // Элементы коллекции, отображаемые во View
    public ICollectionView ItemsView { get; }

    public ICommand CreateItemCommand { get; protected set; }
    public ICommand EditItemCommand { get; protected set; }
    public ICommand<object> RemoveItemCommand { get; protected set; }
    public ICommand<object> ActivateItemCommand { get; protected set; }
    public ICommand<object> DisableItemCommand { get; protected set; }

    public T SelectedItem
    {
        get => GetValue<T>(nameof(SelectedItem));
        set => SetValue(value, nameof(SelectedItem));
    }

    // Поле для текстового поиска с автоматическим обновлением коллекции
    public virtual string SearchText
    {
        get => GetValue<string>(nameof(SearchText));
        set => SetValue(value, () => ItemsView.Refresh(), nameof(SearchText));
    }

    public BaseItemsViewModel()
    {
        _items = new ObservableCollection<T>();
        ItemsView = CollectionViewSource.GetDefaultView(_items);
        ItemsView.Filter += CanFilterItem;

        LoadViewDataCommand = new AsyncCommand(LoadItems);
    }

    /// <summary>
    /// Метод для получения списка, отображаемого на View.
    /// </summary>
    /// <returns></returns>
    public abstract Task<IReadOnlyList<T>> GetItems();

    /// <summary>
    /// Метод для получения списка значений для поиска с View.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public abstract IReadOnlyList<string> GetItemSearchProperties(T item);

    public async Task LoadItems()
    {
        await Execute(async () =>
        {
            _items.Clear();
            var items = await GetItems();
            _items.AddRange(items);
        });
    }

    private bool CanFilterItem(object obj)
    {
        if (SearchText is { } && obj is T item)
        {
            var predicates = GetItemSearchProperties(item)
                .Where(x => x != null)
                .ToList();

            return predicates.Any(x => x.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
        }

        return true;
    }

    public async Task ReplaceItem(Predicate<T> predicate, T newItem)
    {
        await Execute(async () =>
        {
            var index = _items.IndexOf(predicate);

            if (index >= 0)
            {
                _items.RemoveAt(index);
                _items.Insert(index, newItem);
            }
        });
    }

    public async Task RemoveItem(Predicate<T> predicate)
    {
        await Execute(async () =>
        {
            var index = _items.IndexOf(predicate);

            if (index >= 0)
            {
                _items.RemoveAt(index);
            }
        });
    }
}
