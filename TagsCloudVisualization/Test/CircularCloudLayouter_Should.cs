using System.Drawing;
using Moq;
using NUnit.Framework;
using TagsCloudVisualization.CircularCloud.CloudLayouter;
using TagsCloudVisualization.CircularCloud.RectanglePlacer;

namespace TagsCloudVisualization.Test
{
	public class CircularCloudLayouter_Should
	{
		[TestCase(1)]
		[TestCase(100)]
		public void CircularCloudLayouter_ShoulCallFindLocationForEachRectangle_OnlyOnce(int count)
		{
			var config = new Config(null, Size.Empty, Point.Empty, null, 100, false, false, true);
			var placer = new Mock<IRectanglePlacer>();
			var layouter = new CircularCloudLayouter(config, placer.Object);
			var size = new Size(1, 1);
			for (var i = 0; i < count; i++)
				layouter.PutNextRectangle(size);
			placer.Verify(lw => lw.FindLocationForRectangle(size), Times.Exactly(count));
		}
	}
}