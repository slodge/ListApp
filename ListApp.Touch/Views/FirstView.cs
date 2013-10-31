using System;
using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using ListApp.Core.ViewModels;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace ListApp.Touch.Views
{
    [Register("FirstView")]
    public class FirstView : MvxTableViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new MySource(TableView);
            TableView.Source = source;

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(source).For(s => s.ItemsSource).To(vm => vm.Items);
            set.Apply();
        }

        public class MySource : MvxTableViewSource
        {
            public MySource(UITableView tableView) : base(tableView)
            {
                tableView.RegisterClassForCellReuse(typeof(FirstCell), FirstCell.Key);
                tableView.RegisterClassForCellReuse(typeof(SecondCell), SecondCell.Key);
            }

            protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
            {
                var listItem = (ItemViewModel) item;
                if (listItem.Index%5 == 0)
                    return tableView.DequeueReusableCell(FirstCell.Key, indexPath);
                return tableView.DequeueReusableCell(SecondCell.Key, indexPath);
            }
        }
    }

    [Register("FirstCell")]
    public class FirstCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("FirstCell");
        private UILabel _label;

        public FirstCell(IntPtr handle)
            : base(handle)
        {
            _label = new UILabel(new RectangleF(0, 0, 320, 44));
            _label.BackgroundColor = UIColor.Blue;
            _label.TextColor = UIColor.White;
            Add(_label);

            this.DelayBind(() =>
                {
                    var set = this.CreateBindingSet<FirstCell, ItemViewModel>();
                    set.Bind(_label).To(vm => vm.Name);
                    set.Apply();
                });
        }
    }

    [Register("SecondCell")]
    public class SecondCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("SecondCell");
        private UILabel _label;

        public SecondCell(IntPtr handle)
            : base(handle)
        {
            _label = new UILabel(new RectangleF(0, 0, 320, 44));
            _label.BackgroundColor = UIColor.Red;
            _label.TextColor = UIColor.White;
            Add(_label);

            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<SecondCell, ItemViewModel>();
                set.Bind(_label).To(vm => vm.Name);
                set.Apply();
            });
        }
    }

}