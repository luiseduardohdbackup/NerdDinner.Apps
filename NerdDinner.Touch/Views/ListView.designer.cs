//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace NerdDinner.Touch
{
    [Register("ListView")]
    partial class ListView
    {
        [Outlet]
        MonoTouch.UIKit.UITableView TableView { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (TableView != null)
            {
                TableView.Dispose();
                TableView = null;
            }
        }
    }
}

