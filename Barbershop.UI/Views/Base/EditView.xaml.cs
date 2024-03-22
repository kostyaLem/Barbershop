using Barbershop.UI.ViewModels.Pages.Edit;
using Barbershop.UI.Views.Pages.Edit;
using System.Windows.Controls;
using Window = HandyControl.Controls.Window;

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

        Left = (System.Windows.SystemParameters.WorkArea.Width / 2) - (ContextItem.Width / 2);
        Top = (System.Windows.SystemParameters.WorkArea.Height / 2) - (ContextItem.Height / 2);
    }

    public EditView(CreateOrderPage page)
    {
        InitializeComponent();
        Title = "Создание заказа";
        ContextItem = page;
        DataContext = this;

        buttonsGroup.Visibility = System.Windows.Visibility.Collapsed;

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
