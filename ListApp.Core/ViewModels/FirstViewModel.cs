using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;

namespace ListApp.Core.ViewModels
{
    public class ItemViewModel
        : MvxNotifyPropertyChanged
    {
        private int _index;
        public int Index 
        {   
            get { return _index; }
            set { _index = value; RaisePropertyChanged(() => Index); }
        }

        private string _name;
        public string Name 
        {   
            get { return _name; }
            set { _name = value; RaisePropertyChanged(() => Name); }
        }
    }

    public class FirstViewModel 
		: MvxViewModel
    {
        private List<ItemViewModel> _items;
        public List<ItemViewModel> Items 
        {   
            get { return _items; }
            set { _items = value; RaisePropertyChanged(() => Items); }
        }

        public FirstViewModel()
        {
            _items = new List<ItemViewModel>();
            for (var i = 0; i < 10000; i++)
            {
                _items.Add(new ItemViewModel()
                    {
                        Index = i,
                        Name = "Name:" + i
                    });
            }
        }
    }
}
