

using System;


namespace Alpha.Droid.Contracts
{

	public interface ICustomPresenter {
		void Register ( Type viewModelType, IFragmentHost host );
	}

}


