using System.Collections.Generic;

namespace TagsCloudVisualization.TagReader
{
	public interface ITagReader
	{
		Dictionary<string, int> GetFrequency(IEnumerable<string> dict, int wordsCount);
		IEnumerable<string> Read(string path);
	}
}