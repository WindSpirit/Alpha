

// http://arvid-g.de/12/android-4-actionbar-with-tabs-example


using Android.OS;

using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;


namespace Alpha.Droid.Fragments
{
	public class TabFragment1 : MvxFragment
	{
		public override Android.Views.View OnCreateView ( Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState )
		{
			var ignored = base.OnCreateView ( inflater, container, savedInstanceState );
			return this.BindingInflate ( Resource.Layout.TabFrag1, null );
		}
	}
}

