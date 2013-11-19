using Cirrious.MvvmCross.ViewModels;
using NerdDinner.Core;
using NerdDinner.Mobile.Services;
using System;
using System.Collections.Generic;

namespace NerdDinner.Mobile.ViewModels
{
	public class ListViewModel 
		: MvxViewModel
	{
		private readonly INerdDinnerService _dinnerService;

		public ListViewModel(INerdDinnerService dinnerService)
		{
			_dinnerService = dinnerService;
		}

		public override void Start()
		{
			IsLoading = true;
			_dinnerService.GetFeedItems(OnDinnerItems, OnError);
		}

		private void OnDinnerItems(List<Dinner> list)
		{
			IsLoading = false;
			Items = list;
		}

		private void OnError(Exception error)
		{
			// not reported for now
			IsLoading = false;
		}

		private bool _isLoading;
		public bool IsLoading
		{
			get { return _isLoading; }
			set { _isLoading = value; RaisePropertyChanged(() => IsLoading); }
		}

		private List<Dinner> _items;
		public List<Dinner> Items
		{
			get { return _items; }
			set { _items = value; RaisePropertyChanged(() => Items); }
		}

		private Cirrious.MvvmCross.ViewModels.MvxCommand<Dinner> _itemSelectedCommand;
		public System.Windows.Input.ICommand ItemSelectedCommand
		{
			get
			{
				_itemSelectedCommand = _itemSelectedCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand<Dinner>(DoSelectItem);
				return _itemSelectedCommand;
			}
		}

		private void DoSelectItem(Dinner item)
		{
			///ShowViewModel<DetailViewModel>(item);
		}
	}
}
