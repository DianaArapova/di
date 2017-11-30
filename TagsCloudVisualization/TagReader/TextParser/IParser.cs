using System.Collections.Generic;
using System.IO;

namespace TagsCloudVisualization.TagReader.TextParser
{
	public interface IParser
	{
		IEnumerable<string> Parse(StreamReader textReader);
	}
}