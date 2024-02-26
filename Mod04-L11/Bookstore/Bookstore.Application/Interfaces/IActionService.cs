using Bookstore.Application.AppActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.Interfaces
{
  public interface IActionService
  {
    // Application use cases 
    // Book actions
    IActionResult OnAddBook();
    IActionResult OnReadBookDetails();
    IActionResult OnEditBook();
    IActionResult OnDeleteBook();
    IActionResult OnShowBooksList();
    IActionResult OnAutogenBooksList();

    // - Journal actions
    IActionResult OnAddJournal();
    IActionResult OnReadJournalDetails();
    IActionResult OnEditJournal();
    IActionResult OnDeleteJournal();
    IActionResult OnShowJournalList();
    IActionResult OnAutogenJournalList();
  }
}
