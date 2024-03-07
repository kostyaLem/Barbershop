namespace Barbershop.UI.ViewModels
{
    /// <summary>
    /// Модель, описывающая элемент списка меню.
    /// </summary>
    public class ItemViewModel
    {
        public string Header { get; set; }

        public string ImageName { get; set; }

        public ItemViewModel(string header, string imageName)
        {
            Header = header;
            ImageName = imageName;
        }
    }
}
