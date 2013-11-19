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
                ((ListViewModel)ViewModel).ItemSelectedCommand.Execute(e.AddedItems[0]);
                ((ListBox)sender).SelectedIndex = -1;
            }
        }
    }
}