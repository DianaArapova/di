using System.Drawing;

namespace TagsCloudVisualization.CircularCloud.CloudLayouter
{
	public interface ICircularCloudLayouter
	{
		Rectangle PutNextRectangle(Size rectangleSize);
	}
}