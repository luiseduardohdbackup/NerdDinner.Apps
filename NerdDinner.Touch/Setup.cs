using MonoTouch.UIKit;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Touch.Platform;

namespace NerdDinner.Touch
{
	public class Setup : MvxTouchSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
			: base(applicationDelegate, window)
		{
		}

		protected override IMvxApplication CreateApp ()
		{
			return new Mobile.App();
		}
		
		protected override IMvxTrace CreateDebugTrace()
		{
			return new DebugTrace();
		}
	}
}