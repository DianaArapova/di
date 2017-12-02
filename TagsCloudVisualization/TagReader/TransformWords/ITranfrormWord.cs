using System.Collections.Generic;

namespace TagsCloudVisualization.TagReader.TransformWords
{
	public interface ITranfrormWord
	{
		IEnumerable<string> Transform(IEnumerable<string> wordlist);
	}
}