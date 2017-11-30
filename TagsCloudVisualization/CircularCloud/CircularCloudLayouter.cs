using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagsCloudVisualization.RectanglePlacer;

namespace TagsCloudVisualization.CircularCloud
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

		/*public void DrawCloud(string nameOfFile)
		{
			var height = 0;
			var width = 0;
			foreach (var rectangle in cloudOfRectangles)
			{
				width = Math.Max(width, rectangle.X + rectangle.Width);
				height = Math.Max(height, rectangle.Y + rectangle.Height);
			}

			var bitmap = new Bitmap(width + 100, height + 100);
			var graphics = Graphics.FromImage(bitmap);
			var centerRect = new Rectangle(center, new Size(1, 1));
			graphics.DrawRectangle(new Pen(Color.Brown), centerRect);
			foreach (var rectangle in cloudOfRectangles)
				graphics.DrawRectangle(new Pen(Color.Brown), rectangle);
			graphics.Dispose();
			bitmap.Save(nameOfFile);
		}*/
	}

	
}
