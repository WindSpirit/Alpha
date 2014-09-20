

using System;
using System.Net;

using Alpha.Core.Contracts;


namespace Alpha.Droid.Contracts.Impl
{
	// Example of a (possible) device dependent component & service.

	// A component is a small unit of reusable code.
	// It should implement and expose just one service, and do it well.
	// In practical terms, a component is a class that implements a service (interface).
	// The interface is the contract of the service,
	// which creates an abstraction layer so you can replace the service implementation without effort.

	// see also http://dotnetslackers.com/articles/designpatterns/InversionOfControlAndDependencyInjectionWithCastleWindsorContainerPart1.aspx
	public class HttpFileDownloader : IFileDownloader
	{
		public string Download(Uri file)
		{
			return new WebClient ( ).DownloadString ( file );
		}
	}
}

