using Bookstore.Application.Interfaces;
using Bookstore.Domain.Models;
using Bookstore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.AppActions
{
  public class ActionService : IActionService
  {
    ItemService<Book> _bookService;
    ItemService<JournalIssue> _journalService;

    VMActionsBook _vmBookActions;
    VMActionsJournal _vmJournalActions;

    public ActionService(
    ItemService<Book> bookService,
    ItemService<JournalIssue> journalService)
    {
      _bookService = bookService;
      _journalService = journalService;

      _vmBookActions = new VMActionsBook();
      _vmJournalActions = new VMActionsJournal();
    }

    // Book
    public IActionResult OnAddBook()
    {
      Book newBook = _vmBookActions.Create();
      _bookService.Add(newBook);
      return new ActionResult { IsSuccess = true, ResultMessage = "" }; 
    }
    public IActionResult OnReadBookDetails()
    {
      if (_bookService.RepositoryIsEmpty())
      {
        Console.WriteLine("[Backend list is empty]");
        return new ActionResult { IsSuccess = false, ResultMessage = "" };
      }

      List<int> validIds = _bookService.GetIdList();
      int id = _vmBookActions.SelectId(validIds);
      Book book = _bookService.Read(id);
      _vmBookActions.Show(book);
      return new ActionResult { IsSuccess = true, ResultMessage = "" };
    }
    public IActionResult OnEditBook()
    {
      List<int> validIds = _bookService.GetIdList();
      int id = _vmBookActions.SelectId(validIds);
      Book book = _bookService.Read(id);

      Book bookUpdate = _vmBookActions.Edit(book);
      _bookService.Update(id, bookUpdate);
      return new ActionResult { IsSuccess = true, ResultMessage = "" };
    }
    public IActionResult OnDeleteBook()
    {
      if (_bookService.RepositoryIsEmpty())
      {
        Console.WriteLine("[Backend list is empty]");
        return new ActionResult { IsSuccess = false, ResultMessage = "" };
      }

      List<int> validIds = _bookService.GetIdList();
      int id = _vmBookActions.SelectId(validIds);
      _bookService.Delete(id);

      Console.WriteLine("[DONE]");
      return new ActionResult { IsSuccess = true, ResultMessage = "" };
    }
    public IActionResult OnShowBooksList()
    {
      List<Book> list = _bookService.ReadAll();
      _vmBookActions.ShowList(list);
      return new ActionResult { IsSuccess = true, ResultMessage = "" };
    }
    public IActionResult OnAutogenBooksList()
    {
      Console.WriteLine("[Adding 3 books...]");

      Book book;

      book = new Book();
      book.Title = "The C# Programming Language";
      book.Authors = "Anders Hejlsberg";
      book.Publisher = "Wiley";
      book.Year = 2014;
      _bookService.Add(book);

      book = new Book();
      book.Title = "Beginning gRPC with ASP.NET Core 6";
      book.Authors = "Anthony Giretti";
      book.Publisher = "Apress";
      book.Year = 2022;
      _bookService.Add(book);

      book = new Book();
      book.Title = "Learn PHP 8";
      book.Authors = "Steve Prettyman";
      book.Publisher = "Apress";
      book.Year = 2020;
      _bookService.Add(book);

      return new ActionResult { IsSuccess = true, ResultMessage = "" };
    }

    // Journal
    public IActionResult OnAddJournal()
    {
      JournalIssue journalIssue = _vmJournalActions.Create();
      _journalService.Add(journalIssue);
      return new ActionResult { IsSuccess = true, ResultMessage = "" };
    }
    public IActionResult OnReadJournalDetails()
    {
      if (_journalService.RepositoryIsEmpty())
      {
        Console.WriteLine("[Backend list is empty]");
        return new ActionResult { IsSuccess = false, ResultMessage = "" };
      }

      List<int> validIDs = _journalService.GetIdList();
      int id = _vmJournalActions.SelectId(validIDs);
      JournalIssue issue = _journalService.Read(id);
      _vmJournalActions.Show(issue);
      return new ActionResult { IsSuccess = true, ResultMessage = "" };
    }
    public IActionResult OnEditJournal()
    {
      if (_journalService.RepositoryIsEmpty())
      {
        Console.WriteLine("[Backend list is empty]");
        return new ActionResult { IsSuccess = false, ResultMessage = "" };
      }

      List<int> validIDs = _journalService.GetIdList();
      int id = _vmJournalActions.SelectId(validIDs);
      JournalIssue issue = _journalService.Read(id);

      JournalIssue editedIssue = _vmJournalActions.Edit(issue);
      _journalService.Update(id, editedIssue);
      return new ActionResult { IsSuccess = true, ResultMessage = "" };
    }
    public IActionResult OnDeleteJournal()
    {
      if (_journalService.RepositoryIsEmpty())
      {
        Console.WriteLine("[Backend list is empty]");
        return new ActionResult { IsSuccess = false, ResultMessage = "" };
      }

      List<int> validIDs = _journalService.GetIdList();
      int id = _vmJournalActions.SelectId(validIDs);
      _journalService.Delete(id);

      Console.WriteLine("[DONE]");
      return new ActionResult { IsSuccess = true, ResultMessage = "" };
    }
    public IActionResult OnShowJournalList()
    {
      List<JournalIssue> issues = _journalService.ReadAll();
      _vmJournalActions.ShowList(issues);
      return new ActionResult { IsSuccess = true, ResultMessage = "" };
    }
    public IActionResult OnAutogenJournalList()
    {
      JournalIssue issue = null;

      issue = new JournalIssue();
      issue.Name = "MSDN Magazine";
      issue.Year = 2019;
      issue.Vol = 34;
      issue.Nr = 1;
      _journalService.Add(issue);

      issue = new JournalIssue();
      issue.Name = "MSDN Magazine";
      issue.Year = 2019;
      issue.Vol = 34;
      issue.Nr = 2;
      _journalService.Add(issue);

      issue = new JournalIssue();
      issue.Name = "MSDN Magazine";
      issue.Year = 2019;
      issue.Vol = 34;
      issue.Nr = 3;
      _journalService.Add(issue);

      Console.WriteLine("[DONE]");
      return new ActionResult { IsSuccess = true, ResultMessage = "" };
    }
  }
}
