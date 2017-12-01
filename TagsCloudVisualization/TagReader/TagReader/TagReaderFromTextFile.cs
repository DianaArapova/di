using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TagsCloudVisualization.TagReader
{
	public class TagReaderFromTextFile :ITagReader
	{
		public IEnumerable<string> Read(string path)
		{
			return File.ReadLines(path);
		}
	}
}