using Barbershop.UI.ViewModels.Pages.Edit;
using Barbershop.UI.Views.Pages.Edit;
using HandyControl.Controls;
using System.Windows.Controls;

namespace Barbershop.UI.Views.Base;

/// <summary>
/// Логика взаимодействия для EditView.xaml
/// </summary>
public partial class EditView : Window
{
    private bool _isAccept;

    public ContentControl ContextItem { get; }

    public EditView(string title, ContentControl page)
    {
        InitializeComponent();
        Title = title;
        ContextItem = page;
        DataContext = this;
    }

    public EditView(CreateOrderPage page)
    {
        InitializeComponent();
        Title = "Создание заказа";
        ContextItem = page;
        DataContext = this;

        (page.DataContext as CreateOrderViewModel).CreateOrder += EditView_CreateOrder;
    }

    private void EditView_CreateOrder()
    {
        btnOk_Click(null, null);
    }

    private void btnClose_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        DialogResult = false;
        this.Close();
    }

    private void btnOk_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        DialogResult = true;
        _isAccept = true;
        this.Close();
    }

    private void Window_Closed(object sender, System.EventArgs e)
    {
        if (!_isAccept)
        {
            DialogResult = false;
        }

        if (ContextItem.DataContext is CreateOrderViewModel viewModel)
        {
            viewModel.CreateOrder -= EditView_CreateOrder;
        }
    }
}
