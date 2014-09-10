

using System;
using System.Collections.Generic;

using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;

using Alpha.Droid.Contracts;


namespace Alpha.Droid.Specifics {
	public class AlphaCustomPresenter {

		public class CustomPresenter : MvxAndroidViewPresenter, ICustomPresenter {
			// map between view-model and fragment host which creates and shows the view based on the view-model type
			private readonly Dictionary<Type, IFragmentHost> _dictionary = new Dictionary<Type, IFragmentHost> ( );

			public override void Show ( MvxViewModelRequest request ) {
				IFragmentHost host;
				if ( this._dictionary.TryGetValue ( request.ViewModelType, out host ) ) {
					if ( host.Show ( request ) ) {
						return;
					}
				}
				base.Show ( request );
			}

			public void Register ( Type viewModelType, IFragmentHost host ) {
				this._dictionary[viewModelType] = host;
			}
		}

	}
}

