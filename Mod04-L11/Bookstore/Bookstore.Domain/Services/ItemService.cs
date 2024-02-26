
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bookstore.Domain.Interfaces;

namespace Bookstore.Domain.Services
{
  public class ItemService<T> : IItemService<T> where T : IBaseItem
  {
    private IRepository<T> _repository;

    public ItemService(IRepository<T> r)
    {
      _repository = r;
    }

    public int Add(T t)
    {
      int id = _repository.Add(t);
      return id;
    }

    public T Read(int Id)
    {
      return _repository.Read(Id);
    }

    public List<T> ReadAll()
    {
      return _repository.ReadAll();
    }

    public void Update(int Id, T t)
    {
      _repository.Update(Id, t);
    }

    public void Delete(int Id)
    {
      _repository.Delete(Id);
    }

    public List<int> GetIdList()
    {
      return _repository.GetIdList();
    }

    public bool RepositoryIsEmpty()
    {
      return _repository.RepositoryIsEmpty();
    }
  }
}
