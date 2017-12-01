using System.Collections.Generic;

namespace TagsCloudVisualization.TagReader
{
	public interface ITagReader
	{
		IEnumerable<string> Read(string path);
	}
}