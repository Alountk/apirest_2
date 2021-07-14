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
            var items = repository.GetItems().Select(item => item.AsDto());
            return items;
        }

        // GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDTO> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        // POST /items
        [HttpPost]
        public ActionResult<ItemDTO> CreateItem(CreateItemDTO itemDTO)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDTO.Name,
                Price = itemDTO.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            repository.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDTO itemDTO)
        {
            var existingItem = repository.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            {
                Name = itemDTO.Name,
                Price = itemDTO.Price
            };

            repository.UpdateItem(updatedItem);

            return NoContent();
        }
    }
}