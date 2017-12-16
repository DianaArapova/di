using System;
using System.Drawing;
using TagsCloudVisualization.CircularCloud.RectanglePlacer;

namespace TagsCloudVisualization.CircularCloud.CloudLayouter
{
	public class CircularCloudLayouter : ICircularCloudLayouter
	{
		public readonly Point Center;
		private readonly IRectanglePlacer rectanglePlacer;
		
		public CircularCloudLayouter(Config congig, IRectanglePlacer rectanglePlacer)
		{
			var center = congig.Center;
			Center = center;
			this.rectanglePlacer = rectanglePlacer;
		}

		public Result<Rectangle> PutNextRectangle(Size rectangleSize)
		{
			if (rectangleSize.Height < 0 || rectangleSize.Width < 0)
				return Result.Fail<Rectangle>("Size of rectangle is negative");
			return Result.Ok(rectanglePlacer.FindLocationForRectangle(rectangleSize));
		}
	}
}
