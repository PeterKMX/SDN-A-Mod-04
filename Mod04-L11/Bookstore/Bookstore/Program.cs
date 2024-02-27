// Bookstore version: v.4.2.6.25

using System.Reflection;

using Bookstore.Application;
using Bookstore.Domain.Services;
using Bookstore.Domain.Models;
using Bookstore.Application.AppActions;
using Bookstore.Application.Interfaces;

namespace Bookstore
{
  internal class Program
  {
    static void Main(string[] args)
    {
      try
      {
        string appVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        Console.Write($"App: M03-L12 Homework, v.{appVersion}, {DateTime.Now}");
        Console.WriteLine("");
        Console.WriteLine("Welcome to Bookstore application");
        Console.WriteLine("M03-L12 adaptations (#2):");
        Console.WriteLine("- Clean Architecture");
        Console.WriteLine("- Generics");
        Console.WriteLine("- Handles 2 types of items: Book and JournalIssue");
        Console.WriteLine("- Repository interface (in-memory)");
        Console.WriteLine("- Improved consistency of view objects");
        Console.WriteLine("- Uses Clean Architecture dependencies via dlls");
        Console.WriteLine("-----------------------------------------------------------");

        // configure in-memory repositories for Book and JournalIssue   
        Repository<Book> bookRepository = new Repository<Book>();
        Repository<JournalIssue> journalIssueRepository = 
          new Repository<JournalIssue>();

        // configure domain model services 
        ItemService<Book> itemServiceBook = new ItemService<Book>(bookRepository);
        ItemService<JournalIssue> itemServiceJournal = 
          new ItemService<JournalIssue>(journalIssueRepository);

        // configure app menu 
        MenuService mainMenuService = new MenuService();
        mainMenuService.Configure();
        MenuManager mainMenu = new MenuManager(mainMenuService);

        // configure handling of user commands (use case requests received from menu)
        // via ActionDispatcher and via ActionService injection  
        IActionService actionService = new ActionService(itemServiceBook, itemServiceJournal);
        ActionDispatcher actionDispatcher = new ActionDispatcher(actionService);

        IActionResult? actionResult = null; 
        // handle user requests
        while (true)
        {
          MenuActionType userAction = mainMenu.SelectMenuItem();
          if (userAction == MenuActionType.Exit)
          {
            break;
          }
          actionResult = actionDispatcher.OnUserAction(userAction);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Application error occurred {ex.ToString()}");
      }
      finally
      {
        Console.WriteLine();
        Console.WriteLine("STOPPING: Press any key to exit ...");
        string s = Console.ReadLine();
      }
    }
  }
}
