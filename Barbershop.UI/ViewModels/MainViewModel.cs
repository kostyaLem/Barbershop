using Barbershop.UI.Services;
using Barbershop.UI.ViewModels.Base;
using DevExpress.Mvvm;
using HandyControl.Controls;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Barbershop.UI.ViewModels
{
    /// <summary>
    /// Модель главного окна приложения.
    /// </summary>
    public class MainViewModel : BaseItemsViewModel<int>
    {
        public MainViewModel()
        {
            LoadViewDataCommand = new DelegateCommand<SideMenu>(LoadData);
        }

        public void LoadData(SideMenu sideMenu)
        {
            foreach (var item in ViewItemsManager.GetItems())
            {
                var menuItem = new SideMenuItem()
                {
                    Header = $"   {item.Header}",
                    Icon = new Image()
                    {
                        Source = System.Windows.Application.Current.FindResource(item.ImageName) as BitmapImage,
                        Width = 46,
                        Height = 46
                    }
                };

                sideMenu.Items.Add(menuItem);
            }
        }
    }
}
