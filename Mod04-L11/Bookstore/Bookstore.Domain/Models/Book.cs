using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Domain.Interfaces;

namespace Bookstore.Domain.Models
{
  public class Book : IBaseItem
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Authors { get; set; }
    public string Publisher { get; set; }
    public int Year { get; set; }
  }
}
