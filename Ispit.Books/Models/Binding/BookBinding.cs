using Ispit.Books.Models.Dbo;

namespace Ispit.Books.Models.Binding
{
    public class BookBinding
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? AuthorId { get; set; }
        public string? UserId { get; set; }
        public int? PublisherId { get; set; }

    }
}
