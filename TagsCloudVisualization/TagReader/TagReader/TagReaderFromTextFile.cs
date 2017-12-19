using System.Collections.Generic;
using System.IO;

namespace TagsCloudVisualization.TagReader.TagReader
{
	public class TagReaderFromTextFile :ITagReader
	{
		public Result<IEnumerable<string>> Read(string path)
		{
			var result = Result.Of(() => File.ReadLines(path));
			return result.IsSuccess ?
				Result.Ok(File.ReadLines(path)) :
				Result.Fail<IEnumerable<string>>($"File {path} doesn't exit");
		}
	}
}