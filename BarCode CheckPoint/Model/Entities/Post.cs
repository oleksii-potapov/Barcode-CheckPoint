namespace CheckPoint.Model.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string Name { get; set; }
        public override string ToString() => Name;
    }
}