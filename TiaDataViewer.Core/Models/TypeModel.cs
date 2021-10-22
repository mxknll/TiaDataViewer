namespace TiaDataViewer.Core.Models
{
    public class TypeModel
    {
        public string Title { get; set; }

        public int Count { get; set; }

        public string Text => string.IsNullOrWhiteSpace(Title) ? $"<Titel fehlt> ({Count})" : $"{Title} ({Count})";
    }
}
