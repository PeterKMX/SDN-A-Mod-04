
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Domain.Models;

namespace Bookstore.Application
{
  public class VMActionsJournal
  {
    public int SelectId(List<int> idReferenceList)
    {
      // request a valid book id via console 
      // the list idReferenceList is used to check user reply
      string commandText = "Enter Journal Id:";
      Console.WriteLine(commandText);
      int id = ConsoleIO.GetNumber(idReferenceList);
      return id;
    }

    // implements fixed actions set 
    // Create
    // Show
    // Showlist
    // Edit
    // Delete

    //------------------
    // 1 Create
    public JournalIssue Create()
    {
      JournalIssue issue = new JournalIssue();
      issue.Name = GetName();
      issue.Year = GetYear();
      issue.Vol = GetVolume();
      issue.Nr = GetNr();
      return issue;
    }
    //-----------------------------------------
    public string GetName()
    {
      Console.WriteLine("Enter Journal name:");
      return Console.ReadLine();
    }
    //-----------------------------------------
    public int GetYear()
    {
      Console.WriteLine("Enter Journal Year:");
      return ConsoleIO.GetNumber();
    }
    //-----------------------------------------
    public int GetVolume()
    {
      Console.WriteLine("Enter Journal Volume:");
      return ConsoleIO.GetNumber();
    }
    //-----------------------------------------
    public int GetNr()
    {
      Console.WriteLine("Enter Journal Nr:");
      return ConsoleIO.GetNumber();
    }
    //============================================
    // 2 Show
    //-------------------------------------------------------
    public void Show(JournalIssue issue)
    {
      string view = "";

      StringBuilder sb = new StringBuilder();
      sb.AppendLine("Title: " + issue.Name);
      sb.AppendLine("Year: " + issue.Year);
      sb.AppendLine("Vol: " + issue.Vol);
      sb.AppendLine("Nr: " + issue.Nr);
      sb.AppendLine("Id: " + issue.Id);

      view = sb.ToString();
      Console.WriteLine(view);
      return;
    }
    //============================================
    // 3 Show List
    //---------------------------------------------------
    public void ShowList(List<JournalIssue> list)
    {
      Console.WriteLine("---------------------------");
      Console.WriteLine("Showing journal issues list");
      Console.WriteLine("---------------------------");

      if (list != null)
      {
        if (list.Count == 0)
        {
          Console.WriteLine("[Issues list is empty]");
        }
        else
        {
          foreach (JournalIssue issue in list)
          {
            Show(issue);
          }
        }
        Console.WriteLine("---------------------------");
      }
    }

    //============================================
    // 4 Edit
    public JournalIssue Edit(JournalIssue item)
    {
      JournalIssue issue = new JournalIssue();
      issue.Name = EditName(item.Name);
      issue.Vol = EditVol(item.Vol);
      issue.Nr = EditNr(item.Nr);
      issue.Year = EditYear(item.Year);
      issue.Id = item.Id;

      return issue;
    }
    //----------------------------------------------------------
    internal string EditName(string title)
    {
      Console.WriteLine("Current Name:");
      Console.WriteLine(title);
      return GetName();
    }
    //-------------------------------------------------
    internal int EditVol(int vol)
    {
      Console.WriteLine("Current Volume:");
      Console.WriteLine(vol);
      return GetVolume();
    }
    //-----------------------------------------------------
    internal int EditNr(int nr)
    {
      Console.WriteLine("Current Nr:");
      Console.WriteLine(nr);
      return GetNr();
    }
    //-------------------------------------------
    internal int EditYear(int year)
    {
      Console.WriteLine("Year of publication:");
      Console.WriteLine(year);
      return GetYear();
    }

    //============================================
    // 5 Delete

  }
}
