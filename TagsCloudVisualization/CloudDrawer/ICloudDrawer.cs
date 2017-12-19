using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization.CloudDrawer
{
	public interface ICloudDrawer
	{
		Result<Bitmap> Draw(Dictionary<string, Rectangle> tagList);
	}
}