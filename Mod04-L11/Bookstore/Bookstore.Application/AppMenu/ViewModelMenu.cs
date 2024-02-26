using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application
{
  public class ViewModelMenu
  {
    private MenuService _menuService;

    public ViewModelMenu(MenuService menuService)
    {
      _menuService = menuService;
    }
    public MenuActionType SelectMenuActionType()
    {
      // show menu items list
      string menuLines = _menuService.ToString();
      Console.Write(menuLines);

      string commandText = "Enter your menu choice:";
      Console.WriteLine(commandText);

      // reference menu ID's to check user input  
      List<int> allowedMenuIdList = _menuService.GetExistingMenuIdList();

      // convert menu choice to MenuActionType
      return (MenuActionType)ConsoleIO.GetNumber(allowedMenuIdList);
    }
  }
}
