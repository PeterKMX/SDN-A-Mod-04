using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application
{
  public class MenuService
  {
    private List<MenuItem> _menuItemsList;

    public MenuService()
    {
      _menuItemsList = new List<MenuItem>();
    }

    public void Configure()
    {
      _menuItemsList.Add(new MenuItem(11, "Add book to list"));
      _menuItemsList.Add(new MenuItem(12, "Read boek details"));
      _menuItemsList.Add(new MenuItem(13, "Edit book"));
      _menuItemsList.Add(new MenuItem(14, "Remove book from List"));
      _menuItemsList.Add(new MenuItem(15, "View book list"));
      _menuItemsList.Add(new MenuItem(16, "Autogenerate book list"));

      _menuItemsList.Add(new MenuItem(21, "Add journal to list"));
      _menuItemsList.Add(new MenuItem(22, "Read journal details"));
      _menuItemsList.Add(new MenuItem(23, "Edit journal"));
      _menuItemsList.Add(new MenuItem(24, "Remove journal from List"));
      _menuItemsList.Add(new MenuItem(25, "View journal list"));
      _menuItemsList.Add(new MenuItem(26, "Autogenerate journal list"));

      _menuItemsList.Add(new MenuItem(31, "Exit application"));
    }

    public string ToString()
    {
      StringBuilder sbMenuItems = new StringBuilder();
      sbMenuItems.AppendLine("Main Menu:");
      sbMenuItems.AppendLine("----------");
      int item = 0;
      for (int i = 0; i < _menuItemsList.Count; i++)
      {
        sbMenuItems.AppendLine($"{_menuItemsList[i].ToString()}");
        item = i + 1;
        if (item % 6 == 0)
        {
          sbMenuItems.AppendLine($"----");
        }
      }

      return sbMenuItems.ToString();
    }

    public List<int> GetExistingMenuIdList()
    {
      List<int> ints = new List<int>();
      foreach (MenuItem item in _menuItemsList)
      {
        ints.Add(item.Id);
      }

      return ints;
    }
  }
}
