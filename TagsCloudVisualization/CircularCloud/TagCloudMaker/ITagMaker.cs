using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization.CircularCloud.TagCloudMaker
{
	public interface ITagMaker
	{
		Dictionary<string, Rectangle> MakeCloud
			(Dictionary<string, int> tagsList);
	}
}