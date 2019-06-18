using System.ComponentModel.DataAnnotations;

namespace CheckPoint.Model.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        [Required] public string Name { get; set; }
        public override string ToString() => Name;
    }
}