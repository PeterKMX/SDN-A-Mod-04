using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.AppActions
{
  public interface IActionResult
  {
    bool IsSuccess { get; set; }
    string ResultMessage { get; set; }  
  }
}
