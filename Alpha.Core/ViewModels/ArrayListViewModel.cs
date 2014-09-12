

using System.Collections.Generic;

using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;

using Alpha.Droid.Contracts;


namespace Alpha.Core.ViewModels
{
	public class ArrayListViewModel : AbstractViewModel
	{

		public ArrayListViewModel()
		{
			OnListItemClick = new MvxCommand<ListItemContract> ( ListItemClick );
		}

		private int _id;
		public int ID {
			get { return _id; }
			set { SetProperty ( ref _id, value ); }
		}

		private string _caption;
		public string Caption {
			get { return _caption; }
			set { SetProperty ( ref _caption, value ); }
		}

		// ItemsSource List
		private List<ListItemContract> _list;
		public List<ListItemContract> List {
			get { return _list; }
			set { SetProperty ( ref _list, value ); }
		}

		// ItemClick ListItemClick
		public IMvxCommand OnListItemClick { get; private set; }
		private void ListItemClick ( ListItemContract selectedItem )
		{
			Mvx.Trace(MvxTraceLevel.Diagnostic, string.Format("Item cliecked: {0}", selectedItem.Name));
		}

	}
}

