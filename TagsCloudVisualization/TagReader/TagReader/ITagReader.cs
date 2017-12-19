using System.Collections.Generic;

namespace TagsCloudVisualization.TagReader.TagReader
{
	public interface ITagReader
	{
		Result<IEnumerable<string>> Read(string path);
	}
}