using System.Drawing;

namespace TagsCloudVisualization.CircularCloud.CloudLayouter
{
	public interface ICircularCloudLayouter
	{
		Result<Rectangle> PutNextRectangle(Size rectangleSize);
	}
}