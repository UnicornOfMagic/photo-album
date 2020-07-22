namespace photo_album
{
    public class Photo
    {
        public string Title { get; }
        public int Id { get; }

        public Photo(string title, int id)
        {
            Title = title;
            Id = id;
        }

        public override string ToString()
        {
            return $"[{Id}] {Title}";
        }
    }
}