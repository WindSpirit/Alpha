

using Android.Content;

using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;

using Alpha.Droid.Contracts;
using Alpha.Droid.Specifics;


namespace Alpha.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

		protected override IMvxAndroidViewPresenter CreateViewPresenter ( )
		{
			var customPresenter = new AlphaCustomPresenter.CustomPresenter ( );
			Mvx.RegisterSingleton<ICustomPresenter> ( customPresenter );
			return customPresenter;
		}
    }
}

