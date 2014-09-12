

using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Cirrious.MvvmCross.ViewModels;

using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;

using Alpha.Core.ViewModels;
using Alpha.Droid.Fragments;
using Alpha.Droid.Compatibility;


namespace Alpha.Droid.Activities
{
	[Activity (
		Label = "My Fragment State Pager",
		Theme = "@style/Theme.AppCompat.Light",
		Icon = "@drawable/icon" /*,
		MainLauncher = true */
	)]
	public class FragmentStatePagerActivity : MvxActionBarActivity
	{
		public const int ITEMS = 8;

		private MyAdapter mAdapter;
		private ViewPager mPager;

		protected override void OnCreate ( Bundle bundle )
		{
			base.OnCreate ( bundle );
			SetContentView ( Resource.Layout.fragment_pager );

			mAdapter = new MyAdapter(SupportFragmentManager);

			mPager = FindViewById<ViewPager>(Resource.Id.pager);
			mPager.Adapter = mAdapter;

			// // Xamarin way
			// FindViewById<Button>(Resource.Id.first).Click += delegate { mPager.SetCurrentItem(0, true); };
			// FindViewById<Button>(Resource.Id.last).Click += delegate { mPager.SetCurrentItem(ITEMS - 1, true); };

			// // MvvmCross way
			var vm = (ViewModel as FragmentStatePagerViewModel);
			vm.OnMoveFirst = new MvxCommand (() => mPager.SetCurrentItem(0, true));
			vm.OnMoveLast = new MvxCommand (() => mPager.SetCurrentItem(ITEMS - 1, true));
		}


		// Not implemented / needed
		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			var ignore = base.OnCreateOptionsMenu(menu);
			MenuInflater.Inflate(Resource.Menu.main_menu, menu);
			return true;
		}

		public class MyAdapter : FragmentStatePagerAdapter
		{
			public MyAdapter ( FragmentManager fm ) : base ( fm ) { }

			public override int Count {
				get { return ITEMS; }
			}

			public override Fragment GetItem ( int position )
			{
				switch (position)
				{
					case 0: return ImageFragment.init(position);
					case 1: return ImageFragment.init(position);
					default: return ArrayListFragment.init(position);
				}
			}
		}

	}
}

