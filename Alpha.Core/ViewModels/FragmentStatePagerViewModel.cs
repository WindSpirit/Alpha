

using Cirrious.MvvmCross.ViewModels;


namespace Alpha.Core.ViewModels
{
	public class FragmentStatePagerViewModel : AbstractViewModel
	{
		private IMvxCommand _onMoveFirst;
		public IMvxCommand OnMoveFirst
		{
			get { return _onMoveFirst; }
			set { SetProperty(ref _onMoveFirst, value); }
		}

		private IMvxCommand _onMoveLast;
		public IMvxCommand OnMoveLast {
			get { return _onMoveLast; }
			set { SetProperty ( ref _onMoveLast, value ); }
		}
	}
}

