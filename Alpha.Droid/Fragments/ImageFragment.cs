

using Alpha.Core.ViewModels;
using Android.OS;
using Android.Widget;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;


namespace Alpha.Droid.Fragments
{
	public class ImageFragment : MvxFragment
	{
		private int fragVal;

		static public ImageFragment init(int val)
		{
			var newFrag = Mvx.IocConstruct<ImageFragment>( );
			var args = new Bundle();
			args.PutInt("val", val);
			newFrag.Arguments = args;
			return newFrag;
		}


		public override void OnCreate ( Bundle savedInstanceState ) {
			base.OnCreate ( savedInstanceState );

			ViewModel = Mvx.IocConstruct<ImageViewModel> ( );

			fragVal = (Arguments != null) ? Arguments.GetInt("val") : 1;
		}

		public override Android.Views.View OnCreateView ( Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState ) {
			var ignored = base.OnCreateView ( inflater, container, savedInstanceState );
			
			// // Xamarin way
			// var result = inflater.Inflate(Resource.Layout.image_fragment, null);
			// var tv = result.FindViewById<TextView> ( Resource.Id.text );
			// tv.Text = string.Format("Fragment # {0}", fragVal);

			// // MvvmCross way
			var result = this.BindingInflate(Resource.Layout.image_fragment, null);
			var vm = ( ViewModel as ImageViewModel );
			vm.Caption = string.Format ( "Fragment # {0}", fragVal );

			return result;
		}
	}
}

