using System;
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using NerdDinner.Mobile.ViewModels;

namespace NerdDinner.Touch
{
    public partial class ListView : MvxViewController
    {
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public ListView()
            : base(UserInterfaceIdiomIsPhone ? "ListView_iPhone" : "ListView_iPad", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new MvxStandardTableViewSource(TableView, "TitleText Item.Title");
            this.CreateBinding(source).To<ListViewModel>(vm => vm.Items).Apply();
            this.CreateBinding(source).For(s => s.SelectionChangedCommand).To<DinnerWithCommand>(vm => vm.Command).Apply();
            TableView.Source = source;
            TableView.ReloadData();
        }
    }
}



