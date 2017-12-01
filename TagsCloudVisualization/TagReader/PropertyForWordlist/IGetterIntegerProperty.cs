using System.Collections.Generic;

namespace TagsCloudVisualization.TagReader.PropertyForWordlist
{
	public interface IGetterIntegerProperty
	{
		Dictionary<string, int> GetProperty(IEnumerable<string> wordlist);
	}
}