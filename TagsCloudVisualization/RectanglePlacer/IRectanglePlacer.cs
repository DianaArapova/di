using System.Drawing;

namespace TagsCloudVisualization.RectanglePlacer
{
	public interface IRectanglePlacer
	{
		Rectangle FindLocationForRectangle(Size size);
	}
}