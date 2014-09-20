

using System.Globalization;

namespace Alpha.Core.Contracts
{
	public interface ILocalizedText
	{
		string GetLocalizedText(string key, CultureInfo ci);
	}
}

