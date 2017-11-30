using System.Drawing;

namespace TagsCloudVisualization.CircularCloud
{
	public interface ICircularCloudLayouter
	{
		Rectangle PutNextRectangle(Size rectangleSize);
	}
}