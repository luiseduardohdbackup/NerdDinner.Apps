using System;
using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.CoreFoundation;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using NerdDinner.Mobile.ViewModels;

namespace NerdDinner.Touch.Views
{
    [Register("DetailView")]
    public class DetailView : MvxViewController
    {
        public DetailView()
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
            View = new UIView() { BackgroundColor = UIColor.White };

            base.ViewDidLoad();

            // Perform any additional setup after loading the view
            var titleLabel = new UILabel(new RectangleF(10, 100, 300, 40));
            Add(titleLabel);

            var descriptionLabel = new UILabel(new RectangleF(10, 140, 300, 40));
            Add(descriptionLabel);

            var eventDateLable = new UILabel(new RectangleF(10, 180, 300, 40));
            Add(eventDateLable);

            var hostedByLabel = new UILabel(new RectangleF(10, 220, 300, 40));
            Add(hostedByLabel);

            var set = this.CreateBindingSet<DetailView, DetailViewModel>();
            set.Bind(titleLabel).To(vm => vm.Item.Title);
            set.Bind(descriptionLabel).To(vm => vm.Item.Description);
            set.Bind(eventDateLable).To(vm => vm.Item.EventDate);
            set.Bind(hostedByLabel).To(vm => vm.Item.HostedBy);
            set.Apply();
        }
    }
}