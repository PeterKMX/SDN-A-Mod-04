using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application
{
  public static class ConsoleIO
  {
    public static int GetNumber()
    {
      string tmp = Console.ReadLine();
      int number = 0;
      bool hasError = !int.TryParse(tmp, out number);
      if (number <= 0)
      {
        hasError = true;
      }
      int errorCount = 0;
      while (hasError)
      {
        errorCount++;
        if (errorCount >= 3)
        {
          Console.WriteLine("Too many errors on input, skipping this question ...");
          break;
        }
        Console.WriteLine("Inorrect input, please enter your age:");
        tmp = Console.ReadLine();
        hasError = !int.TryParse(tmp, out number);
        if (number <= 0)
        {
          hasError = true;
        }
      }
      return number;
    }

    public static int GetNumber(List<int> validIdList)
    {
      string tmp = Console.ReadLine();
      int number = 0;
      bool error = !int.TryParse(tmp, out number);
      if (!error)
      {
        error = !validIdList.Contains(number);
      }
      int errorCount = 0;
      while (error)
      {
        errorCount++;
        if (errorCount >= 3)
        {
          Console.WriteLine("Too many errors on input, skipping this question ...");
          break;
        }
        Console.WriteLine("Inorrect input, please enter your age:");
        tmp = Console.ReadLine();
        error = !int.TryParse(tmp, out number);
        if (!error)
        {
          error = !validIdList.Contains(number);
        }
      }
      return number;
    }
  }
}
