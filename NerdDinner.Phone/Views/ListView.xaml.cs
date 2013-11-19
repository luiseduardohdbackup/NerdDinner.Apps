using Cirrious.MvvmCross.WindowsPhone.Views;
using NerdDinner.Mobile.ViewModels;
using System.Windows.Controls;

namespace NerdDinner.Phone.Views
{
    public partial class ListView : MvxPhonePage
    {
        public ListView()
        {
            InitializeComponent();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                var item = e.AddedItems[0] as DinnerWithCommand;
                item.Command.Execute(item.Item);
                ((ListBox)sender).SelectedIndex = -1;
            }
        }
    }
}