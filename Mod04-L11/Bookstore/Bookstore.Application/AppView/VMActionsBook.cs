
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Domain.Models;

namespace Bookstore.Application
{
  // View Model VMActionsBook
  // class can be derived from Book entity, but not now
  // 
  // class VMActionsBook implements fixed actions set for Book
  // SelectId
  // Create
  // Show
  // ShowList
  // Edit
  // Delete
  public class VMActionsBook
  {
    // 0 SelectId
    public int SelectId(List<int> idReferenceList)
    {
      string commandText = "Enter Book Id:";
      Console.WriteLine(commandText);
      int id = ConsoleIO.GetNumber(idReferenceList);
      return id;
    }

    // 1 Create
    public Book Create()
    {
      Book book = new Book();
      book.Title = GetTitle();
      book.Authors = GetAuthors();
      book.Publisher = GetPublisher();
      book.Year = GetYear();

      return book;
    }

    public string GetTitle()
    {
      Console.WriteLine("Enter book title:");
      return Console.ReadLine();
    }

    public string GetAuthors()
    {
      Console.WriteLine("Enter authors:");
      return Console.ReadLine();
    }

    public string GetPublisher()
    {
      Console.WriteLine("Enter publisher:");
      return Console.ReadLine();
    }

    public int GetYear()
    {
      Console.WriteLine("Enter year:");
      return ConsoleIO.GetNumber();
    }

    // 2 Show
    public void Show(Book book)
    {
      string bookView = "";

      StringBuilder sb = new StringBuilder();
      sb.AppendLine("Title: " + book.Title);
      sb.AppendLine("Authors: " + book.Authors);
      sb.AppendLine("Publisher: " + book.Publisher);
      sb.AppendLine("Year: " + book.Year);
      sb.AppendLine("Id: " + book.Id);

      bookView = sb.ToString();
      Console.WriteLine(bookView);
      return;
    }

    // 3 ShowList
    public void ShowList(List<Book> list)
    {
      Console.WriteLine("-----------------------");
      Console.WriteLine("Showing books list");
      Console.WriteLine("-----------------------");

      if (list != null)
      {
        if (list.Count == 0)
        {
          Console.WriteLine("[Books list is empty]");
        }
        else
        {
          string bookView = "";
          foreach (Book book in list)
          {
            Show(book);
          }
        }
        Console.WriteLine("-----------------------");
      }
    }

    // 4 Edit
    public Book Edit(Book currentBook)
    {
      Book editedBook = new Book();
      editedBook.Title = EditTitle(currentBook.Title);
      editedBook.Authors = EditAuthors(currentBook.Authors);
      editedBook.Publisher = EditPublisher(currentBook.Publisher);
      editedBook.Year = EditYear(currentBook.Year);
      editedBook.Id = currentBook.Id;

      return editedBook;
    }

    internal string EditTitle(string title)
    {
      Console.WriteLine("Current Title:");
      Console.WriteLine(title);
      return GetTitle();
    }

    internal string EditAuthors(string authors)
    {
      Console.WriteLine("Current Authors:");
      Console.WriteLine(authors);
      return GetAuthors();
    }

    internal string EditPublisher(string publisher)
    {
      Console.WriteLine("Current Publisher:");
      Console.WriteLine(publisher);
      return GetPublisher();
    }

    internal int EditYear(int year)
    {
      Console.WriteLine("Current year of publication");
      Console.WriteLine(year);
      return GetYear();
    }

    // 5 Delete
    // no specific action :
    //   SelectId is used to read Id from view 
    //   to delete book item with this id via 
    //   the domain service
  }
}
