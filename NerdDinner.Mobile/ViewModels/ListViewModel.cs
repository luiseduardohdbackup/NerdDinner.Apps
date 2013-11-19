using Cirrious.MvvmCross.ViewModels;
using NerdDinner.Core;
using NerdDinner.Mobile.Services;
using NerdDinner.Mobile.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NerdDinner.Mobile.ViewModels
{
	public class DinnerWithCommand : WithCommand<Dinner>
	{
		public DinnerWithCommand(Dinner item, Action<Dinner> tapAction)
			: base(item, new MvxCommand(() => tapAction(item)))
		{
		}
	}

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

			var newList = list.AsEnumerable().Select(x => new DinnerWithCommand(x, DoSelectItem));
            Items = new List<DinnerWithCommand>(newList);
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

		private List<DinnerWithCommand> _items;
		public List<DinnerWithCommand> Items
		{
			get { return _items; }
			set { _items = value; RaisePropertyChanged(() => Items); }
		}

		private void DoSelectItem(Dinner item)
		{
			ShowViewModel<DetailViewModel>(item);
		}
	}
}
