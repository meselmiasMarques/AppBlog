namespace AppBlog.Entities.Domain
{
    public class Category
    {
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
            Posts = new List<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Post> Posts { get; set; }
    }
}
