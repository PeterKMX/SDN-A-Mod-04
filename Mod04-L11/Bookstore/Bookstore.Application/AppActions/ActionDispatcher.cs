using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Application.AppActions;
using Bookstore.Application.Interfaces;
using Bookstore.Domain.Models;
using Bookstore.Domain.Services;

namespace Bookstore.Application
{
  public class ActionDispatcher
  {
    IActionService _iActionService;
    public ActionDispatcher(IActionService iActionService)
    {
      _iActionService = iActionService;
    }
    public IActionResult OnUserAction(MenuActionType actionType)
    {
      IActionResult result = actionType switch
      {
        // book 
        MenuActionType.AddBook => _iActionService.OnAddBook(),
        MenuActionType.ReadBookDetails => _iActionService.OnReadBookDetails(),
        MenuActionType.ReadBooksList => _iActionService.OnShowBooksList(),
        MenuActionType.EditBook => _iActionService.OnEditBook(),
        MenuActionType.RemoveBook => _iActionService.OnDeleteBook(),
        MenuActionType.AutogenBooksList => _iActionService.OnAutogenBooksList(),
        // journal
        MenuActionType.AddJournal => _iActionService.OnAddJournal(),
        MenuActionType.ReadDetailsJournal => _iActionService.OnReadJournalDetails(),
        MenuActionType.ReadJournalList => _iActionService.OnShowJournalList(),
        MenuActionType.EditJournal => _iActionService.OnEditJournal(),
        MenuActionType.RemoveJournal => _iActionService.OnDeleteJournal(),
        MenuActionType.AutogenJournalList => _iActionService.OnAutogenJournalList(),

        _ => throw new Exception("Error: unknown user action")
      };

      return result;  
    }
   
  }
}
