using System;
using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization.CloudDrawer
{
	public class CloudDrawer : ICloudDrawer
	{
		private readonly Brush tagColor;
		private readonly string tagFontName;
		private Size imageSize;

		public CloudDrawer(Brush tagColor, string tagFontName, Size imageSize)
		{
			this.tagColor = tagColor;
			this.tagFontName = tagFontName;
			this.imageSize = imageSize;
		}

		public Bitmap Draw(Dictionary<string, Rectangle> tagList)
		{
			var bitmap = new Bitmap(imageSize.Width, imageSize.Height);
			using (var gr = Graphics.FromImage(bitmap))
			{
				foreach (var tag in tagList)
				{
					gr.DrawRectangle(new Pen(Color.Black), tag.Value);
					gr.DrawString(tag.Key, new Font(tagFontName, tag.Value.Height / 2), tagColor,
						tag.Value.Location);
				}
			}
			return bitmap;
		}
	}
}