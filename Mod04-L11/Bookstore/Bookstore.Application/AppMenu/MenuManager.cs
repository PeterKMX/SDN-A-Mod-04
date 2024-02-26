using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application
{
  public class MenuManager
  {
    private MenuService _menuService;
    private ViewModelMenu _vmMenu;

    public MenuManager(MenuService menuService)
    {
      _vmMenu = new ViewModelMenu(menuService);
    }

    public MenuActionType SelectMenuItem()
    {
      MenuActionType  actionType = _vmMenu.SelectMenuActionType();
      return actionType;
    }
  }
}
