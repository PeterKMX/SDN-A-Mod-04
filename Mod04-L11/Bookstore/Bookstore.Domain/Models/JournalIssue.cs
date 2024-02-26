using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Domain.Interfaces;

namespace Bookstore.Domain.Models
{
  public class JournalIssue : IBaseItem
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public int Vol { get; set; }
    public int Nr { get; set; }

  }
}
