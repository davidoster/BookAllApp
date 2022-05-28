using BookAllApp.Models;
using System.Collections.Generic;

namespace BookAllApp.Repositories
{
    public interface IBookRepository
    {
        Book GetBookById(string bookId);
        Book Create(Book book);
        Book Update(Book book);
        Book Delete(string ID);

        IEnumerable<Book> AllBooks { get; }
        IEnumerable<Book> MostSelledBooks { get; }

    }
}
