using System.Drawing;
using TagsCloudVisualization.CircularCloud;
using TagsCloudVisualization.RectanglePlacer;

namespace TagsCloudVisualization
{
	public class Program
	{
		public static void Main()
		{
			var center = new Point(150, 150);
			var cloud = new CircularCloudLayouter(new Point(150, 150), 
				new DefaultRectanglePlacer(center));
			const int count = 50;
			for (var i = 0; i < count; i++)
			{
				cloud.PutNextRectangle(new Size(20, 20));
				if (i < 5)
					cloud.PutNextRectangle(new Size(40, 40));
			}

			//cloud.DrawCloud("cloud.bmp");
		}
	}
}
