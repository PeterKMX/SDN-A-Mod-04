using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

using Bookstore.Domain.Models;
using Bookstore.Domain.Interfaces;

namespace Bookstore.Domain.Test.SelfShunt.Simulation
{
  public class RepositorySim<T> : IRepository<T> where T : IBaseItem
  {
    private List<T> _list;

    public RepositorySim()
    {
      _list = new List<T>();
    }

    public int Add(T t)
    {
      int id = GenerateNewId();
      t.Id = id;
      _list.Add(t);

      return id;  
    }

    public T Read(int id)
    {
      T t = FindItemById(id);
      return t;
    }

    public List<T> ReadAll()
    {
      return _list;
    }

    public void Update(int Id, T t)
    {
      int index = FindItemIndexById(Id);
      if (index != -1)
      {
        _list[index] = t;
      }
      else
      {
        throw new Exception($"Error: Update: {Id} could not be found");
      }
    }

    public void Delete(int id)
    {
      int index = FindItemIndexById(id);
      _list.RemoveAt(index);
    }

    public List<int> GetIdList()
    {
      List<int> idList = new List<int>();
      for (int i = 0; i < _list.Count; i++)
      {
        idList.Add(_list[i].Id);
      }

      return idList;
    }

    public bool RepositoryIsEmpty()
    {
      return _list.Count == 0;
    }

    // generic helper functions

    public T FindItemById(int id)
    {
      T itemFound = default;
      bool found = false;
      foreach (T t in _list)
      {
        if (t.Id == id)
        {
          itemFound = t;
          found = true;
          break;
        }
      }

      if (!found)
      {
        throw new Exception($"Error: could not find item by Id {id}");
      }

      return itemFound;
    }

    private int FindItemIndexById(int id)
    {
      int index = -1;
      for (int i = 0; i < _list.Count; i++)
      {
        if (_list[i].Id == id)
        {
          index = i;
          break;
        }
      }

      return index;
    }

    // internal repo-specific actions

    private int GenerateNewId()
    {
      int highestCurrendtId = 0;

      List<int> idList = new List<int>();
      foreach (T t in _list)
      {
        idList.Add(t.Id);
      }

      if (idList.Count > 0)
      {
        // sorts ascending
        idList.Sort();
        highestCurrendtId = idList[idList.Count - 1];
      }

      int newId = highestCurrendtId + 1;
      return newId;
    }

    public int GetItemId(T t)
    {
      throw new NotImplementedException();
    }
  }
}
