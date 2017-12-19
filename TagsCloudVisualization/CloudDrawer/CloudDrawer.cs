using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TagsCloudVisualization.CloudDrawer
{
	public class CloudDrawer : ICloudDrawer
	{
		private readonly Brush[] tagColor;
		private readonly string tagFontName;
		private Size imageSize;

		public CloudDrawer(Config config)
		{
			tagColor = config.TagColor;
			tagFontName = config.TagFontName;
			imageSize = config.ImageSize;
		}

		public Result<Bitmap> Draw(Dictionary<string, Rectangle> tagList)
		{
			var fontResult = Result.Of(() => new Font(tagFontName, 1));
			if (!fontResult.IsSuccess)
				return Result.Fail<Bitmap>($"Font {tagFontName} doesn't exit");
			if (!CheckImageSize(tagList))
				return Result.Fail<Bitmap>("Size of bitmap isn't enough for cloud.");
			var bitmap = new Bitmap(imageSize.Width, imageSize.Height);
			using (var gr = Graphics.FromImage(bitmap))
			{
				var random = new Random();
				foreach (var tag in tagList)
				{
					var index = random.Next(3);
					gr.DrawString(tag.Key, 
						new Font(tagFontName, tag.Value.Height / 2), 
						tagColor[index],
						tag.Value.Location);

				}
			}
			return Result.Ok(bitmap);
		}

		private bool IsRectangleIsInside(Rectangle rectangle)
		{
			return rectangle.Left >= 0 && rectangle.Right <= imageSize.Width
			       && rectangle.Top >= 0 && rectangle.Bottom <= imageSize.Height;
		}

		private bool CheckImageSize(Dictionary<string, Rectangle> tagList)
		{
			return tagList.Select(tag => tag.Value)
				.All(IsRectangleIsInside);
		}
	}
}