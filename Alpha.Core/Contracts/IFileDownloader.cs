

using System;


namespace Alpha.Core.Contracts
{
	// Service - Download a file
	public interface IFileDownloader
	{
		string Download(Uri file);
	}
}

