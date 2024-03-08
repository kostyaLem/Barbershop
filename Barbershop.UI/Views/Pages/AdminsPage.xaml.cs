using Barbershop.UI.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Barbershop.UI.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminsPage.xaml
    /// </summary>
    public partial class AdminsPage : Page
    {
        public AdminsPage(AdminsPageViewModel context)
        {
            InitializeComponent();
            DataContext = context;
        }
    }
}
