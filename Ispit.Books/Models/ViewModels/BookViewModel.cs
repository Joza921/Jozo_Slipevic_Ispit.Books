using Ispit.Books.Models.Dbo;

namespace Ispit.Books.Models.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }   
        public Author? Author { get; set; }       
        public Publisher? Publisher { get; set; }

    }
}
