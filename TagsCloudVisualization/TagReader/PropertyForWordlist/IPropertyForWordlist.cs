using System.Collections.Generic;

namespace TagsCloudVisualization.TagReader.PropertyForWordlist
{
	public interface IPropertyForWordlist
	{
		Dictionary<string, int> GetProperty(IEnumerable<string> wordlist);
	}
}