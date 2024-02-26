using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application
{
  public enum MenuActionDEMO
  {
    AddBook = 11,
    ReadBookDetails = 12
  }

  public enum MenuActionType
  {
    AddBook = 11,
    ReadBookDetails = 12, 
    EditBook = 13,
    RemoveBook = 14,
    ReadBooksList =15,   
    AutogenBooksList = 16,

    AddJournal = 21,
    ReadDetailsJournal = 22,
    EditJournal = 23,
    RemoveJournal = 24,
    ReadJournalList = 25,
    AutogenJournalList = 26,

    Exit = 31
  }
}
