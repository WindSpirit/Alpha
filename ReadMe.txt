
=====================================================================================================================
This solution illustrates many fundamental Android / Xamarin / MvvmCross design principles.
=====================================================================================================================


The introduction of MvxActionBarActivity class which makes Support v4 & v7 available (e.g.: ActionBar & Fragments).

	Alpha.Droid / Compatibility / MvxActionBarActivity.cs
	Alpha.Droid / Compatibility / MvxActionBarEventSourceActivity.cs
	Alpha.Droid / Activities / MainActivity.cs


The implementation of an ActionBar Tab that uses a fragment for each tab.

	Alpha.Droid / Activities / MainActivity.cs
	Alpha.Droid / Fragments / TabFragment1.cs
	Alpha.Droid / Fragments / TabFragment2.cs
	Alpha.Droid / Specifics / TabListenerImpl.cs


An example of LastCustomNonConfigurationInstance to tombstone information, which is particularily useful when the device is rotated.

	Alpha.Droid / Activities / MainActivity.cs
	Alpha.Droid / Contracts / MainActivityBag.cs
	Alpha.Droid / Activities / ActivityStorageBag.cs


Nesting of fragments.

	Alpha.Droid / Fragments / TabFragment2.cs

	Alpha.Droid / Contracts / IFragmentHost.cs
	
	Alpha.Droid / Fragments / FirstFrag.cs
	Alpha.Droid / Fragments / SecondFrag.cs
	Alpha.Droid / Fragments / ThirdFrag.cs

	Alpha.Core / ViewModels / TabFrag2ViewModel.cs

	Alpha.Core / ViewModels / FirstFragViewModel.cs
	Alpha.Core / ViewModels / SecondFragViewModel.cs
	Alpha.Core / VideModels / ThirdFragViewModel.cs

	>> Custom (Android) Presenter


Custom (Android) Presenter

	Alpha.Droid / Fragments / TabFragment2.cs

	Alpha.Droid / Specifics / AlphaCustomPresenter.cs

	Alpha.Droid / Contracts / ICustomPresenter.cs


Fragment Menu Support

	Alpha.Droid / Fragments / TabFragment1.cs


Fragment / View Parameter Passing	

	Alpha.Droid / Fragments / TabFragment2.cs

	Alpha.Core / ViewModels / TabFrag2ViewModel.cs
	Alpha.Core / ViewModels / FirstFragViewModel.cs
		
