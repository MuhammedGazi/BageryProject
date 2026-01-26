namespace Bagery.Business.DTOs.OrderDTOs;

public class OrderItemDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

