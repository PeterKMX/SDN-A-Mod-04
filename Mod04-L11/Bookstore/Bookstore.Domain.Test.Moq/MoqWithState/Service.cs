using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Test.Moq.MoqWithState
{
  public class Service
  {
    IFoo _foo { get; set; }
    public Service(IFoo foo) 
    {
      _foo = foo;
    }
    public int DoSomething(string s) 
    { 
      return _foo.DoSomething(s);
    }
    public int DoSomething(int i, string s)
    {
      return _foo.DoSomething(i,s);
    }
  }
}
