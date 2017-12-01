namespace TagsCloudVisualization.TagReader.TagFilter
{
	public interface ITagFilter
	{
		bool IsSuitableWorld(string word);
	}
}