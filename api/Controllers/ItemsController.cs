using System;
using System.Collections.Generic;
using System.Linq;
using api.DTOs;
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
    private readonly IItemsRepository repository;
    public ItemsController(IItemsRepository _repository)
    {
      repository = _repository;
    }

    [HttpGet]
    public IEnumerable<ItemDTO> GetItems()
    {
      var items = repository.GetItems().Select( item => item.AsDto());
      return items;
    }

    // GET /items/{id}
    [HttpGet("{id}")]
    public ActionResult<ItemDTO> GetItem(Guid id)
    {
      var item = repository.GetItem(id);
      
      if(item is null)
      {
        return NotFound();
      }
      
      return item.AsDto();
    }
  }
}