using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TagsCloudVisualization.RectanglePlacer;

namespace TagsCloudVisualization.CircularCloud
{
	[TestFixture]
	class CircularCloudLayouter_Should
	{

		private CircularCloudLayouter cloud = new CircularCloudLayouter(new Point(30, 30), 
			new DefaultRectanglePlacer(new Point(30, 30)));

		[TearDown]
		public void TearDown()
		{
			if (!TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
				return;

			var nameOfFile = TestContext.CurrentContext.TestDirectory +
							 TestContext.CurrentContext.Test.Name + ".bmp";
			//cloud.DrawCloud(nameOfFile);

			Console.WriteLine("Tag cloud visualization saved to file " +
							  nameOfFile);
		}

		[TestCase(10, 10)]
		[TestCase(11, 11)]
		[TestCase(10, 8)]
		public void PutNextRectangle_CenterOfFirstRectangle_IsSutuated_InCenterOfCloud
			(int width, int height)
		{
			var center = new Point(120, 120);
			cloud = new CircularCloudLayouter(center, new DefaultRectanglePlacer(center));
			var x = center.X - width / 2;
			var y = center.Y - height / 2;
			var rectangle = new Rectangle(x, y, width, height);
			cloud.PutNextRectangle(new Size(width, height)).ShouldBeEquivalentTo(rectangle);
		}

		[Test]
		public void PutNextRectangle_ReturnNotFirstRectangleWithRigthSize()
		{
			var center = new Point(12, 12);
			cloud = new CircularCloudLayouter(center, new DefaultRectanglePlacer(center));
			var sizeOfRectangle = new Size(4, 4);
			cloud.PutNextRectangle(sizeOfRectangle);
			cloud.PutNextRectangle(sizeOfRectangle).Size.
				ShouldBeEquivalentTo(sizeOfRectangle);
		}

		[TestCase(2, 4, 4)]
		[TestCase(50, 40, 40)]
		[TestCase(100, 4, 4)]
		[TestCase(100, 4, 2)]
		[TestCase(500, 2, 2), Timeout(3000)]
		public void PutNextRectangle_ReturnRectangles_DoNotHaveIntersection(int count, int width, int height)
		{
			var center = new Point(150, 150);
			cloud = new CircularCloudLayouter(center, new DefaultRectanglePlacer(center));
			var listOfRectangles = new List<Rectangle>();
			for (var i = 0; i < count; i++)
			{
				listOfRectangles.Add(cloud.PutNextRectangle(new Size(width, height)));
			}
			listOfRectangles.SelectMany(a => listOfRectangles, (n, a) => new { n, a }).
				Where(a => a.a != a.n).
				All(a => !a.a.IntersectsWith(a.n)).
				Should().BeTrue();
		}

		[Test]
		public void PutNextRectangle_CenterWithNegativeCoordinates_ThrowException()
		{
			var center = new Point(-1, 7);
			Assert.Throws<ArgumentException>(() =>
			new CircularCloudLayouter(center, new DefaultRectanglePlacer(center)));
		}

		[Test]
		public void PutNextRectangle_GetRectangleWithNegativeSize_ThrowException()
		{
			var center = new Point(6, 7);
			cloud = new CircularCloudLayouter(center, new DefaultRectanglePlacer(center));
			Assert.Throws<ArgumentException>(() => cloud.PutNextRectangle(new Size(4, -4)));
		}

		private static double DistanceBetweenTwoPoint(Point point1, Point point2)
		{
			var point = new Point(point1.X - point2.X, point1.Y - point2.Y);
			return Math.Sqrt(point.X * point.X + point.Y * point.Y);
		}

		[TestCase(1, 2, 2)]
		[TestCase(10, 10, 10)]
		[TestCase(100, 6, 4)]
		[TestCase(100, 10, 10)]
		[TestCase(500, 1, 1)]
		[TestCase(5000, 1, 1)]
		public void PutRectangles_RadiusOfCloud_IsLessThenDoubleRadiusOfCircle_WithAreaSumOfAreasOfRectangles
			(int count, int width, int height)
		{
			var center = new Point(150, 150);
			cloud = new CircularCloudLayouter(center, new DefaultRectanglePlacer(center));
			double area = 0;
			double radiusOfCloud = 0;
			for (var i = 0; i < count; i++)
			{
				var rectangle = cloud.PutNextRectangle(new Size(height, width));
				area += rectangle.Height * rectangle.Width;
				radiusOfCloud = Math.Max(radiusOfCloud,
					DistanceBetweenTwoPoint(center, rectangle.Location));
			}
			var radiusOfCircle = Math.Sqrt(area / Math.PI);
			radiusOfCloud.Should().BeLessThan(4 * radiusOfCircle);
		}
	}
}