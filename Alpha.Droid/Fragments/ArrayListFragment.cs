

using System;
using System.Collections.Generic;
using System.Linq;
using Alpha.Core.ViewModels;
using Alpha.Droid.Contracts;
using Android.OS;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Core;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;


namespace Alpha.Droid.Fragments
{
	// Implementation based on http://www.truiton.com/2013/05/android-fragmentpageradapter-example/

	// https://github.com/MvvmCross/MvvmCross/issues/326
	// "The list activity and list fragment are both not included because they don't really offer any advantage for data-binding"
	// "It's easier to use a normal activity or fragment and just fill that activity or fragment with an MvxListView"
	// Missing advantage?  Yep!  Portability and compatibility... forced to translate & convert existing Java logic...
	// Regardless, next step, to use MvxListView
	public class ArrayListFragment : MvxFragment // ListFragment
	{
		private int fragNum;

		private readonly String[] _arrayList = new String[]
		{
			"This is",
			"a Truiton",
			"Demo",
			"App",
			"For",
			"Showing",
			"FragmentStatePagerAdapter",
			"and ViewPager",
			"Implementation"
		};

		public static ArrayListFragment init(int val)
		{
			var newFrag = Mvx.IocConstruct<ArrayListFragment>();
			var args = new Bundle();
			args.PutInt("val", val);
			newFrag.Arguments = args;
			return newFrag;
		}

		// Retrieving this instance's number from its arguments.
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			ViewModel = Mvx.IocConstruct<ArrayListViewModel> ( );

			fragNum = Arguments != null ? Arguments.GetInt("val") : 1;
		}

		// The Fragment's UI is a simple text view showing its instance number and an associated list.
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var ignored = base.OnCreateView(inflater, container, savedInstanceState);

			// // Xamarin way
			//var result = inflater.Inflate(Resource.Layout.fragment_pager_list, container, false);

			//var tv = result.FindViewById<TextView>(Resource.Id.text);
			//tv.Text = string.Format("Fragment # {0}", fragNum);

			// // MvvmCross way
			var result = this.BindingInflate( Resource.Layout.fragment_pager_list, null );

			var vm = ( ViewModel as ArrayListViewModel );
			vm.ID = fragNum;
			vm.Caption = string.Format ( "Fragment # {0}", fragNum );
			vm.List = _arrayList.Select(entry => new ListItemContract() {Name = entry}).ToList();

			return result;
		}

		// // Xamarin way
		//public override void OnActivityCreated(Bundle savedInstanceState)
		//{
		//	base.OnActivityCreated(savedInstanceState);
		//	ListAdapter = new ArrayAdapter<String>(Activity, Android.Resource.Layout.SimpleListItem1, _arrayList);
		//}

		// // MvvmCross way
		//public override void OnListItemClick(ListView l, View v, int position, long id)
		//{
		//	base.OnListItemClick(l, v, position, id);
		//	Log.Info ( "Truiton FragmentList", "Item clicked: " + id );
		//}
	}
}

