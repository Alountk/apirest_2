using System;
using System.Collections.Generic;
using api.Entities;
using api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [ApiController]
  // [Route("[controller]")] 
  [Route("items")] 
  public class ItemsController : ControllerBase
  {
    private readonly InMemItemsRepository repository;
    public ItemsController()
    {
      repository = new InMemItemsRepository();
    }

    [HttpGet]
    public IEnumerable<Item> GetItems()
    {
      var items = repository.GetItems();
      return items;
    }

    // GET /items/{id}
    [HttpGet("{id}")]
    public ActionResult<Item> GetItem(Guid id)
    {
      var item = repository.GetItem(id);
      
      if(item is null)
      {
        return NotFound();
      }
      
      return item;
    }
  }
}