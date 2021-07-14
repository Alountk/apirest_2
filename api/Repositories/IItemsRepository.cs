using System;
using System.Collections.Generic;
using api.Entities;

namespace api.Repositories
{

  public interface IItemsRepository
  {
    Item GetItem(Guid id);
    IEnumerable<Item> GetItems();
    void CreateItem (Item item);
    void UpdateItem (Item item);
  }
}