using ProductTrial.Domain.Entities;

namespace ProductTrial.Domain.Models;

public record CreateProduct(
    string Code,
    string Name,
    string Description,
    string Image,
    string Category,
    decimal Price,
    int Quantity,
    string InternalReference,
    int ShellId,
    InventoryStatus InventoryStatus,
    int Rating
);
