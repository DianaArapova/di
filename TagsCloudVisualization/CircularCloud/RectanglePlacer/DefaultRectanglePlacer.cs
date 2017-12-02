using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TagsCloudVisualization.CircularCloud.RectanglePlacer
{
	public class DefaultRectanglePlacer : IRectanglePlacer
	{
		private readonly Point center;
		private int radius;
		private readonly List<Rectangle> cloudOfRectangles;

		public DefaultRectanglePlacer(Config config)
		{
			center = config.Center;
			cloudOfRectangles = new List<Rectangle>();
		}

		private static Rectangle GetRectangle(Size rectangleSize, Point center)
		{
			return new Rectangle(center.X - rectangleSize.Width / 2,
				center.Y - rectangleSize.Height / 2,
				rectangleSize.Width,
				rectangleSize.Height);
		}

		private bool ValidateRectangle(Rectangle rectangle)
		{
			if (rectangle.X < 0 || rectangle.Y < 0)
				return false;
			return cloudOfRectangles.All(r => !r.IntersectsWith(rectangle));
		}

		private void UpdateRadius(Rectangle rectangle)
		{
			radius -= (int)Math.Sqrt(rectangle.Height * rectangle.Height +
			                         rectangle.Width * rectangle.Width);
			radius = Math.Max(0, radius);
		}

		private static Point ShiftPoint(Point point, double x, double y)
		{
			return new Point((int)(point.X + x), (int)(point.Y + y));
		}

		public Rectangle FindLocationForRectangle(Size rectangleSize)
		{
			var isAnswerFind = false;
			var rectangle = new Rectangle();

			while (!isAnswerFind)
			{
				for (double i = 0; i < 2 * Math.PI; i += Math.PI / 30)
				{
					var locationOfRectangle =
						ShiftPoint(center, radius * Math.Cos(i), radius * Math.Sin(i));

					rectangle = GetRectangle(rectangleSize, locationOfRectangle);
					if (ValidateRectangle(rectangle))
					{
						isAnswerFind = true;
						break;
					}
				}
				radius += 1;
			}

			UpdateRadius(rectangle);
			cloudOfRectangles.Add(rectangle);
			return rectangle;
		}
	}
}