namespace AppBlog.Entities.Domain
{
    public class Post
    {
        public Post(int id, string title, string content, DateTime createdAt, DateTime? updatedAt, int categoryId)
        {
            Id = id;
            Title = title;
            Content = content;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            CategoryId = categoryId;
            Tags = new List<Tag>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int CategoryId { get; set; }

        public IList<Tag> Tags { get; set; }

    }
}
