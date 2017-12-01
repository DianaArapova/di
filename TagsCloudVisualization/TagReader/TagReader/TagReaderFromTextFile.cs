using System.Collections.Generic;
using System.IO;

namespace TagsCloudVisualization.TagReader.TagReader
{
	public class TagReaderFromTextFile :ITagReader
	{
		public IEnumerable<string> Read(string path)
		{
			return File.ReadLines(path);
		}
	}
}