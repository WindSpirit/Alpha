

using System.Reflection;
using Alpha.Droid.Modules;
using Android.Content;

using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;

using Autofac;

using Alpha.Core;
using Alpha.Core.Constituents;
using Alpha.Core.Contracts;
using Alpha.Core.Contracts.Impl;

using Alpha.Droid.Contracts;
using Alpha.Droid.Contracts.Impl;
using Alpha.Droid.Specifics;

using AutofacMvvm;


namespace Alpha.Droid
{
    public class Setup : MvxAndroidSetup
    {
		private static Assembly CoreAssembly { get { return typeof ( App ).Assembly; } }

		// The following override does not get called, probably because we replaced the container...
		protected override IMvxIocOptions CreateIocOptions ( )
		{
			//	Property injection, where attributed as such.  Example:
			//	public class MyViewModel : MvxViewModel
			//	{
			//		[MvxInject]
			//		public IFooService Foo { get; set; }
			//	}
			return new MvxIocOptions() { PropertyInjectorOptions = MvxPropertyInjectorOptions.MvxInject }; 
		}

		public Setup ( Context applicationContext ) : base ( applicationContext ) { }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }


		/*
		 * This enables the use of Autofac unhindered, as the only IOC container.
		 * Autofac is by far the best IOC container available for .NET.
		 * 
		 */
		protected override IMvxIoCProvider CreateIocProvider ( ) {

			// See also https://code.google.com/p/autofac/wiki/ComponentCreation

			// Create your builder
			var cb = new ContainerBuilder ( );

			// Structure app using Autofac modules, as it keeps everything very DRY (Don't Repeat Yourself)
			// and SRP (Single Responsibility Principle) compliant.
			// Autofac modules should be held in a separate PCL so they can be used by
			// Android / iOS / WP platforms without violating DRY.
			

			// Registrations can be managed in logical (Module) groups.
			// See also RegisterModule<> ( );
			cb.RegisterModule( new HtmlScrapingModule() );

			// This is an important step that ensures all the ViewModel's are loaded into the container.
			// Without this, it was observed that MvvmCross wouldn't register them by itself; needs more investigation.
			cb.RegisterAssemblyTypes ( CoreAssembly )
				.AssignableTo<MvxViewModel> ( )
				.As<IMvxViewModel, MvxViewModel> ( )
				.AsSelf ( );

			return new AutofacMvxIocProvider ( cb.Build ( ) );
		}


		protected override IMvxAndroidViewPresenter CreateViewPresenter ( )
		{
			var customPresenter = new AlphaCustomPresenter.CustomPresenter ( );
			Mvx.RegisterSingleton<ICustomPresenter> ( customPresenter );
			return customPresenter;
		}
    }
}

