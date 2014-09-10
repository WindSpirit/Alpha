

using Android.OS;

using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;


namespace Alpha.Droid.Fragments
{
	public class ThirdFrag : MvxFragment
	{
		public override Android.Views.View OnCreateView ( Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState ) {
			var ignored = base.OnCreateView ( inflater, container, savedInstanceState );
			return this.BindingInflate ( Resource.Layout.ThirdFrag, null );
		}
	}
}

