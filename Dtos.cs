using System;

namespace playFileService.Dtos
{
    public class Dtos
    {
        public record ItemDto (Guid Id, string Name, string Description, decimal Price, DateTimeOffset Date);
        public record CreateItemDto(string Name, string Description, decimal Price);
        public record UpdateItemDto(string Name, string Description, decimal Price);
    }
}
