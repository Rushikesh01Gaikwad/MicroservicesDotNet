using Microsoft.AspNetCore.Mvc;
using static playFileService.Dtos.Dtos;

namespace playFileService.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
      private static readonly List<ItemDto> items = new List<ItemDto>
      {
          new ItemDto(Guid.NewGuid(), "Item1", "Description1", 10.99m, DateTimeOffset.UtcNow),
          new ItemDto(Guid.NewGuid(), "Item2", "Description2", 20.99m, DateTimeOffset.UtcNow),
          new ItemDto(Guid.NewGuid(), "Item3", "Description3", 30.99m, DateTimeOffset.UtcNow)
      };

        [HttpGet]
        public ActionResult<IEnumerable<ItemDto>> GetItems()
        {
            return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto createItemDto)
        {
            var newItem = new ItemDto(Guid.NewGuid(), createItemDto.Name, createItemDto.Description, createItemDto.Price, DateTimeOffset.UtcNow);
            items.Add(newItem);
            return newItem;
                /*CreatedAtAction(nameof(GetItem), new { id = newItem.Id }, newItem);*/
        }
    }
}
