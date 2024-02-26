using Bookstore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Utilities
{
  public class BookCreator
  {
    public static Book CreateBook(int param)
    {
      Book b = new Book()
      {
        Title = "Title" + param,
        Authors = "Authors"+ param,
        Publisher = "Publisher"+ param,
        Year = 2020 + param,
        Id = 0
      };
      return b;
    }

    public static List<Book> CreateBookList(int count)
    {
      List < Book > books = new List<Book>(); 
      for (int i = 1; i <= count; ++i ) 
      { 
        books.Add(CreateBook(i));
      }
      return books;
    }
    public static List<Book> CreateBookList(int count, bool withIDs)
    {
      Book b;
      List<Book> books = new List<Book>();
      for (int i = 1; i <= count; ++i)
      {
        b = CreateBook(i);
        if (withIDs) b.Id = i;
        books.Add(b);
      }
      return books;
    }

    public static Book CreateUpdatedBook(Book b)
    {
      Book bookUpdated = new Book();
      bookUpdated.Title = b.Title + "-Updated";
      bookUpdated.Authors = b.Authors + "-Updated";
      bookUpdated.Publisher = b.Publisher + "-Updated";
      bookUpdated.Year = b.Year + 1;
      bookUpdated.Id = b.Id;
      return bookUpdated; 
    }
  }
}
