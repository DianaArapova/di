using System;
using System.Drawing;
using TagsCloudVisualization.CircularCloud.RectanglePlacer;

namespace TagsCloudVisualization.CircularCloud.CloudLayouter
{
	public class CircularCloudLayouter : ICircularCloudLayouter
	{
		public readonly Point Center;
		private readonly IRectanglePlacer rectanglePlacer;
		
		public CircularCloudLayouter(Point center, IRectanglePlacer rectanglePlacer)
		{
			if (center.X < 0 || center.Y < 0)
				throw new ArgumentException("Coordinat of center is negative");
			Center = center;
			this.rectanglePlacer = rectanglePlacer;
		}

		public Rectangle PutNextRectangle(Size rectangleSize)
		{
			if (rectangleSize.Height < 0 || rectangleSize.Width < 0)
				throw new ArgumentException("Size of rectangle is negative");
			return rectanglePlacer.FindLocationForRectangle(rectangleSize);
		}
	}
}
