using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Test.Moq.MoqWithState
{
  public interface IFoo
  {
    public int DoSomething();
    public int DoSomething(string s);
    public int DoSomething(int i, string s);
  }
}
