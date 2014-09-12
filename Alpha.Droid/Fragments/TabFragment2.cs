

// http://arvid-g.de/12/android-4-actionbar-with-tabs-example


using Android.OS;
using Android.Support.V4.App;

using Cirrious.CrossCore;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.ViewModels;

using Alpha.Core.ViewModels;
using Alpha.Droid.Contracts;


namespace Alpha.Droid.Fragments
{
	public class TabFragment2 : MvxFragment, IFragmentHost
	{
		public const string ActiveFragmentId = "ActiveFragment";
			
		protected readonly int FirstFragment = typeof ( FirstFragViewModel ).GetHashCode ( );
		protected readonly int SecondFragment = typeof ( SecondFragViewModel ).GetHashCode ( );
		protected readonly int ThirdFragment = typeof ( ThirdFragViewModel ).GetHashCode ( );

		protected int CurrentFragment;

		private ICustomPresenter _presenter = null;
		public ICustomPresenter Presenter { get { return _presenter = _presenter ?? Mvx.Resolve<ICustomPresenter> ( ); } }

		public TabFragment2()
		{
			// Humpty Dumpty sat on a wall,
			// Humpty Dumpty had a great fall,
			// All the king's horses and all the king's men
			// Couldn't put Humpty together again.

			// We MUST RetainInstance!  Otherwise, we won't be able to rehydrate our view!
			RetainInstance = true;

			// We MUST establish Arguments, if we want to use it for tombstoning!
			Arguments = new Bundle ( );
			CurrentFragment = FirstFragment;
		}

		public override Android.Views.View OnCreateView ( Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState )
		{
			Presenter.Register ( typeof ( FirstFragViewModel ), this );
			Presenter.Register ( typeof ( SecondFragViewModel ), this );
			Presenter.Register ( typeof ( ThirdFragViewModel ), this );

			var ignored = base.OnCreateView ( inflater, container, savedInstanceState );

			return this.BindingInflate ( Resource.Layout.TabFrag2, null );
		}

		public override void OnPause ( )
		{
			Arguments.PutInt ( ActiveFragmentId, CurrentFragment );
			base.OnPause ( );
		}

		public override void OnResume ( )
		{
			CurrentFragment = Arguments.GetInt ( ActiveFragmentId );
			Show ( GetViewModelRequestByHashCode ( CurrentFragment ) );
			base.OnResume ( );
		}

		public bool Show ( MvxViewModelRequest request )
		{
			// Decide fragment to create based on view-model type (hash-code)
			Fragment fragmentView;
			CurrentFragment = request.ViewModelType.GetHashCode ( );
			if ( FirstFragment.Equals ( CurrentFragment ) )
			{
				fragmentView = new FirstFrag ( ) { ViewModel = Mvx.Resolve<IMvxViewModelLoader> ( ).LoadViewModel ( request, null ) };
			}
			else if ( SecondFragment.Equals ( CurrentFragment ) )
			{
				fragmentView = new SecondFrag ( ) { ViewModel = Mvx.Resolve<IMvxViewModelLoader> ( ).LoadViewModel ( request, null ) };
			}
			else if ( ThirdFragment.Equals ( CurrentFragment ) )
			{
				fragmentView = new ThirdFrag ( ) { ViewModel = Mvx.Resolve<IMvxViewModelLoader> ( ).LoadViewModel ( request, null ) };
			}
			else
			{
				fragmentView = new FirstFrag ( ) { ViewModel = Mvx.Resolve<IMvxViewModelLoader> ( ).LoadViewModel ( request, null ) };
			}

			// Load fragment into view (could have been: add / hide / show, rather than replace)
			var ft = FragmentManager.BeginTransaction ( );
			ft.Replace ( Resource.Id.theFrag, fragmentView );
			ft.DisallowAddToBackStack();
			ft.Commit ( );
			return true;
		}


		private MvxViewModelRequest GetViewModelRequestByHashCode(int hashCode)
		{
			if (hashCode.Equals(FirstFragment)) return new MvxViewModelRequest() {ViewModelType = typeof (FirstFragViewModel)};
			if (hashCode.Equals(SecondFragment)) return new MvxViewModelRequest() {ViewModelType = typeof (SecondFragViewModel)};
			if (hashCode.Equals(ThirdFragment)) return new MvxViewModelRequest() {ViewModelType = typeof(ThirdFragViewModel)};
			return new MvxViewModelRequest() {ViewModelType = typeof (FirstFragViewModel)};
		}

	}
}

