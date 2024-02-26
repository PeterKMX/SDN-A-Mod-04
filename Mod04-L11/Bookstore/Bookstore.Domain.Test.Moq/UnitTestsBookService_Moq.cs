using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Models;
using Bookstore.Domain.Services;
using Bookstore.Domain.Test.Moq.MoqWithState;
using Bookstore.Domain.Utilities;
using Moq;
using System.Reflection;

namespace Bookstore.Domain.Test.Moq
{
  public class UnitTestsBookService_Moq
  {
    [Fact]
    public void AddFirstBook_ShouldReturn_Id_1()
    {
      // Arrange
      // mock the repo
      Mock<IRepository<Book>> repositoryBookMock = new Mock<IRepository<Book>>();
      Book b = BookCreator.CreateBook(1);
      repositoryBookMock.Setup(x => x.Add(b)).Returns(1);
      IItemService<Book> bookService = new ItemService<Book>(repositoryBookMock.Object);    
      
      // Act
      int bookId = bookService.Add(b);
      
      // Assert
      Assert.Equal(1, bookId);
    }

    [Fact]
    public void ReadBook_ShouldReturn_AddedBook()
    {
      // Arrange
      RepositoryMoqState<Book> moqState = new RepositoryMoqState<Book>();
      Mock<IRepository<Book>> repositoryBookMock = new Mock<IRepository<Book>>();
      IItemService<Book> bookService = new ItemService<Book>(repositoryBookMock.Object);

      Book book = BookCreator.CreateBook(1);
      repositoryBookMock.Setup(x => x.Add(It.IsAny<Book>()))
                        .Callback<Book>((book) => moqState.Add(book))
                        .Returns(1);
      repositoryBookMock.Setup(x => x.Read(It.IsAny<int>()))
                        .Callback<int>((int x) => moqState.Read(x))
                        .Returns((int x) => moqState.Read(x));

      // Act
      int bookId = bookService.Add(book);
      Book bookRetrieved = bookService.Read(bookId);

      // Assert
      Assert.Equal(bookRetrieved, book);
    }

    [Fact]
    public void ReadAllBooks_ShouldReturn_Added3Books()
    {
      // Arrange part 1
      RepositoryMoqState<Book> moqState = new RepositoryMoqState<Book>();
      Mock<IRepository<Book>> repositoryBookMock = new Mock<IRepository<Book>>();
      IItemService<Book> bookService = new ItemService<Book>(repositoryBookMock.Object);

      // Arrange part 2: callbacks to moqState interface functions
      Book book = BookCreator.CreateBook(1);
      repositoryBookMock.Setup(x => x.Add(It.IsAny<Book>()))
                        .Callback<Book>( (b) => moqState.Add(b));
      repositoryBookMock.Setup(x => x.ReadAll())
                        .Returns(() => moqState._list);

      // Arrange part 3: send data to book service which uses repositoryBookMock.Object
      // and uses callbacks to moqState
      List<Book> bookListToAdd = BookCreator.CreateBookList(3);
      foreach (Book b in bookListToAdd) 
      {
        bookService.Add(b); 
      }

      // Act 
      List<Book> bookListRetrieved = bookService.ReadAll();

      // Assert
      Assert.Equal(bookListRetrieved, bookListToAdd);
    }

    [Fact]
    public void UpdateBook_AndReadById_ShouldReturn_UpdatedBook()
    {
      // Arrange
      RepositoryMoqState<Book> moqState = new RepositoryMoqState<Book>();
      Mock<IRepository<Book>> repositoryBookMock = new Mock<IRepository<Book>>();
      IItemService<Book> bookService = new ItemService<Book>(repositoryBookMock.Object);

      Book book = BookCreator.CreateBook(1);
      repositoryBookMock.Setup(x => x.Add(It.IsAny<Book>()))
                        .Callback<Book>((book) => moqState.Add(book))
                        .Returns(1);
      repositoryBookMock.Setup(x => x.Read(It.IsAny<int>()))
                        .Callback<int>((int x) => moqState.Read(x))
                        .Returns((int x) => moqState.Read(x));
      repositoryBookMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Book>()))
                        .Callback<int, Book>((int x, Book b) => moqState.Update(x, b));

      int bookId = bookService.Add(book);
      Book bookBeforeUpdate = bookService.Read(bookId);
      Book bookUpdated = BookCreator.CreateUpdatedBook(bookBeforeUpdate);

      // Act
      bookService.Update(bookId, bookUpdated);  
      Book bookRetrieved = bookService.Read(bookId);

      // Assert
      Assert.Equal(bookUpdated, bookRetrieved);
    }

    [Fact]
    public void DeleteById_AndReadById_ShouldThrow_AnExeption()
    {
      // Arrange
      RepositoryMoqState<Book> moqState = new RepositoryMoqState<Book>();
      Mock<IRepository<Book>> repositoryBookMock = new Mock<IRepository<Book>>();
      IItemService<Book> bookService = new ItemService<Book>(repositoryBookMock.Object);

      Book book = BookCreator.CreateBook(1);
      repositoryBookMock.Setup(x => x.Add(It.IsAny<Book>()))
                        .Callback<Book>((book) => moqState.Add(book))
                        .Returns(1);

      repositoryBookMock.Setup(x => x.Delete(It.IsAny<int>()))
                        .Callback<int>((x) => moqState.Delete(x));

      repositoryBookMock.Setup(x => x.Read(It.IsAny<int>()))
                        .Callback<int>((int x) => moqState.Read(x))
                        .Returns((int x) => moqState.Read(x));

      int bookId = bookService.Add(book);
      bookService.Delete(bookId);
      var exception = Assert.Throws<Exception>(() => bookService.Read(bookId));
      // Assert
      Assert.NotNull(exception);
      Assert.Equal("Error: could not find item by Id 1", exception.Message);
    }

    [Fact]
    public void GetIdList_ResultShould_BeEqualTo_ReadAll_BookIds()
    {
      // Arrange part 1
      RepositoryMoqState<Book> moqState = new RepositoryMoqState<Book>();
      Mock<IRepository<Book>> repositoryBookMock = new Mock<IRepository<Book>>();
      IItemService<Book> bookService = new ItemService<Book>(repositoryBookMock.Object);

      // Arrange part 2: callbacks to moqState interface functions
      Book book = BookCreator.CreateBook(1);
      repositoryBookMock.Setup(x => x.Add(It.IsAny<Book>()))
                        .Callback<Book>((b) => moqState.Add(b));

      repositoryBookMock.Setup( x => x.GetIdList() )
                        .Callback( () => moqState.GetIdList() )
                        .Returns( () => moqState.GetIdList() );

      repositoryBookMock.Setup(x => x.ReadAll())
                        .Returns(() => moqState._list);

      List<Book> bookListToAdd = BookCreator.CreateBookList(3);
      foreach (Book b in bookListToAdd) { bookService.Add(b); }

      // Act
      List<int> idList = bookService.GetIdList();

      // Assess
      List<Book> bookListRetrieved = bookService.ReadAll();
      bool allIdsFound = true;
      foreach (Book x in bookListRetrieved)
      {
        if (!idList.Contains(x.Id))
        {
          allIdsFound = false;
        }
      }

      Assert.True(allIdsFound);
    }

    [Fact]
    public void RepositoryIsEmpty_ShouldReturnTrue_AfterAllBooksRemoval_X()
    {
      // Arrange
      RepositoryMoqState<Book> moqState = new RepositoryMoqState<Book>();
      Mock<IRepository<Book>> repositoryBookMock = new Mock<IRepository<Book>>();
      IItemService<Book> bookService = new ItemService<Book>(repositoryBookMock.Object);

      // Arrange
      Book book = BookCreator.CreateBook(1);
      repositoryBookMock.Setup(x => x.Add(It.IsAny<Book>()))
                        .Callback<Book>((b) => moqState.Add(b))
                        .Returns((Book b) => moqState.Add(b));

      repositoryBookMock.Setup(x => x.GetIdList())
                        .Callback(() => moqState.GetIdList())
                        .Returns(() => moqState.GetIdList());

      repositoryBookMock.Setup(x => x.Delete(It.IsAny<int>()))
                        .Callback<int>((x) => moqState.Delete(x));

      repositoryBookMock.Setup(x => x.RepositoryIsEmpty())
                        .Callback(() => moqState.RepositoryIsEmpty())
                        .Returns(() => moqState.RepositoryIsEmpty());

      List<Book> bookListToAdd = BookCreator.CreateBookList(3);
      foreach (Book b in bookListToAdd) 
      { 
        bookService.Add(b); 
      }

      // Remove all books
      List<int> idList = bookService.GetIdList();  
      foreach (int id in idList) 
      {
        bookService.Delete(id);
      }
      // Act
      bool isEmpty = bookService.RepositoryIsEmpty();

      // Assert
      Assert.True(isEmpty); 
    }



  }
}