using System.Collections.Generic;

namespace TagsCloudVisualization.TagReader.TextParser
{
	public interface IParser
	{
		IEnumerable<string> Parse(IEnumerable<string> lines);
	}
}