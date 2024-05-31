using AutoMapper;
using Ispit.Books.Models.Binding;
using Ispit.Books.Models.Dbo;
using Ispit.Books.Models.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ispit.Books.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book,BookViewModel>();
            CreateMap<BookBinding, Book>();
            CreateMap<BookBinding, BookViewModel>();
            CreateMap<BookViewModel, BookUpdateBinding>();
            CreateMap<BookUpdateBinding, Book>();

            CreateMap<Author, AuthorViewModel>();
            CreateMap<Publisher, PublisherViewModel>();
        }
    }
}
