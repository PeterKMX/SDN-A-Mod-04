

using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Models;
using Bookstore.Domain.Services;
using Bookstore.Domain.Test.SelfShunt.Simulation;
using Bookstore.Domain.Utilities;

namespace Bookstore.Domain.Test.SelfShunt
{
  public class UnitTestsBookService_SelfShunt
  {
    [Fact]
    public void AddFirstBook_ShouldReturn_Id_1()
    {
      // Arrange
      //  mock the repo
      RepositorySim<Book> bookRepoSimulation = new RepositorySim<Book>();
      //  create a book item
      Book b = BookCreator.CreateBook(1);
      // Act
      IItemService<Book> bookService = new ItemService<Book>(bookRepoSimulation);
      int bookId = bookService.Add(b);
      // Assert
      Assert.Equal(1, bookId);
    }

    [Fact]
    public void ReadBook_ShouldReturn_AddedBook()
    {
      // Arrange
      // mock the repo
      RepositorySim<Book> bookRepoSimulation = new RepositorySim<Book>();
      //  create book item
      Book b = BookCreator.CreateBook(1);
      // Act
      IItemService<Book> bookService = new ItemService<Book>(bookRepoSimulation);
      int bookId = bookService.Add(b);
      Book bookRetrieved = bookService.Read(bookId);
      // Assert
      Assert.Equal(bookRetrieved, b);
    }

    [Fact]
    public void ReadAllBooks_ShouldReturn_AddedBooksList()
    {
      // Arrange
      // mock the repo
      RepositorySim<Book> bookRepoSimulation = new RepositorySim<Book>();
      //  create a list of 3 books
      List<Book> bookList = BookCreator.CreateBookList(3);
      // Act
      IItemService<Book> bookService = new ItemService<Book>(bookRepoSimulation);
      foreach (Book book in bookList) 
      {
        bookService.Add(book);
      }

      List<Book> bookListRetrieved = bookService.ReadAll();

      // Assert
      Assert.Equal(bookListRetrieved, bookList);
    }

    [Fact]
    public void UpdateBook_AndReadById_ShouldReturn_UpdatedBook()
    {
      // Arrange
      // mock the repo
      RepositorySim<Book> bookRepoSimulation = new RepositorySim<Book>();
      //  create book item
      Book b = BookCreator.CreateBook(1);
      // Act
      IItemService<Book> bookService = new ItemService<Book>(bookRepoSimulation);
      int bookId = bookService.Add(b);
      Book bookRetrievedBeforeUpdate = bookService.Read(bookId);
      //  updating retrieved book
      Book bookUpdated = new Book();
      bookUpdated.Title = bookRetrievedBeforeUpdate.Title + "-Updated";
      bookUpdated.Authors = bookRetrievedBeforeUpdate.Authors + "-Updated";
      bookUpdated.Publisher = bookRetrievedBeforeUpdate.Publisher + "-Updated";
      bookUpdated.Year = bookRetrievedBeforeUpdate.Year + 1;
      bookUpdated.Id = bookRetrievedBeforeUpdate.Id;

      bookService.Update(bookId,bookUpdated);

      Book bookRetrievedAfterUpdate = bookService.Read(bookId);  

      // Assert
      Assert.Equal(bookRetrievedAfterUpdate, bookUpdated);
    }

    [Fact]
    public void DeleteById_AndReadById_ShoundReturn_NoBook()
    {
      // Arrange
      //  mock the repo
      RepositorySim<Book> bookRepoSimulation = new RepositorySim<Book>();
      //  create a book item
      Book b = BookCreator.CreateBook(1);
      // Act
      IItemService<Book> bookService = new ItemService<Book>(bookRepoSimulation);
      int bookId = bookService.Add(b);
      bookService.Delete(bookId);
      var exception = Assert.Throws<Exception>( () => bookService.Read(bookId) );
      // Assert
      Assert.NotNull(exception);
      Assert.Equal("Error: could not find item by Id 1", exception.Message);
    }

    [Fact]
    public void GetIdList_ResultShould_BeEqualTo_ReadAll_BookIds() 
    {
      // Arrange
      //   mock the repo
      RepositorySim<Book> bookRepoSimulation = new RepositorySim<Book>();
      //   inject mock     
      IItemService<Book> bookService = new ItemService<Book>(bookRepoSimulation);
      //   create a list of 3 books
      List<Book> bookList = BookCreator.CreateBookList(3);
      //   add via service to repo
      foreach (Book book in bookList)
      {
        bookService.Add(book);
      }
      //   read list via service 
      List<Book> bookListRetrieved = bookService.ReadAll();

      // Act      
      List<int> bookIdList = bookService.GetIdList();

      // Assess
      bool allIdsFound = true;
      foreach (Book book in bookListRetrieved) 
      {
        if (!bookIdList.Contains(book.Id))
        {
          allIdsFound = false;
        }
      }

      Assert.True(allIdsFound); 
    }

    [Fact]
    public void RepositoryIsEmpty_ShouldReturnTrue_AfterAllBoosRemoval() 
    {
      // Arrange
      //   mock the repo
      RepositorySim<Book> bookRepoSimulation = new RepositorySim<Book>();
      //   inject mock     
      IItemService<Book> bookService = new ItemService<Book>(bookRepoSimulation);
      //   create a list of 3 books
      List<Book> bookList = BookCreator.CreateBookList(3);
      //   add via service to repo
      foreach (Book book in bookList)
      {
        bookService.Add(book);
      }
      //   read list via service 
      List<int> bookIdList = bookService.GetIdList();

      // Act  
      foreach (int id in bookIdList) 
      {
        bookService.Delete(id); 
      }
      bool repositoryIsEmpty = bookService.RepositoryIsEmpty(); 

      Assert.True(repositoryIsEmpty);
    }
  }
}