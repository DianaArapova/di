using System.Drawing;

namespace TagsCloudVisualization.CircularCloud.RectanglePlacer
{
	public interface IRectanglePlacer
	{
		Rectangle FindLocationForRectangle(Size size);
	}
}