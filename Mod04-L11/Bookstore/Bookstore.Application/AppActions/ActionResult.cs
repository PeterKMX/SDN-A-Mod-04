using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.AppActions
{
  public class ActionResult : IActionResult
  {
    public bool IsSuccess { get ; set ; }
    public string? ResultMessage { get; set; }
  }
}
