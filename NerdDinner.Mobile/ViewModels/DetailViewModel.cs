using Cirrious.MvvmCross.ViewModels;
using NerdDinner.Core;

namespace NerdDinner.Mobile.ViewModels
{
    public class DetailViewModel : MvxViewModel
    {
        public void Init(Dinner item)
        {
            Item = item;
        }

        private Dinner _dinner;
        public Dinner Item
        {
            get { return _dinner; }
            set { _dinner = value; RaisePropertyChanged(() => Item); }
        }
    }
}
