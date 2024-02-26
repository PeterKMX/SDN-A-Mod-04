using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application
{
  public class MenuItem
  {
    public int Id { get; set; }
    public string Text { get; set; }

    public MenuItem(int id, string text)
    {
      Id = id;
      Text = text;
    }

    public string ToString()
    {
      return $"({Id}) {Text}";
    }
  }
}
