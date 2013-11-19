using Cirrious.MvvmCross.WindowsStore.Views;
using NerdDinner.Mobile.ViewModels;
using Windows.UI.Xaml.Controls;

namespace NerdDinner.Store.Views
{
    public sealed partial class ListView : MvxStorePage
    {
        public ListView()
        {
            this.InitializeComponent();
        }

        private void listBox_SelectionChanged(object sender, Windows.UI.Xaml.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                ((ListViewModel)ViewModel).ItemSelectedCommand.Execute(e.AddedItems[0]);
                ((ListBox)sender).SelectedIndex = -1;
            }
        }
    }
}
