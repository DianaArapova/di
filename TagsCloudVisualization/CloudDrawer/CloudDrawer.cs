using System;
using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization.CloudDrawer
{
	public class CloudDrawer : ICloudDrawer
	{
		private Brush TagColor { get; }
		private string TagFontName { get; }
		private Size ImgSize { get; }

		public CloudDrawer(Brush color, string fontName, Size imgSize)
		{
			TagColor = color;
			TagFontName = fontName;
			ImgSize = imgSize;
		}

		public Bitmap Draw(Dictionary<string, Rectangle> tagList)
		{
			var bitmap = new Bitmap(ImgSize.Width, ImgSize.Height);
			using (var gr = Graphics.FromImage(bitmap))
			{
				foreach (var tag in tagList)
				{
					gr.DrawRectangle(new Pen(Color.Aquamarine), tag.Value);
					gr.DrawString(tag.Key, new Font(TagFontName, GetFontSize(gr, tag.Key, tag.Value)), TagColor,
						tag.Value.Location);
				}
			}
			return bitmap;
		}

		public void DrawCloud(List<Rectangle> cloudOfRectangles, string nameOfFile, Point center)
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
		}

		public int GetFontSize(Graphics gr, string word, Rectangle rectangle)
		{
			return rectangle.Height / 2;
		}
	}
}