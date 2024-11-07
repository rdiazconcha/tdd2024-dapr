using Dapr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceB.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportsController(ILogger<ReportsController> logger) : ControllerBase
{
    [Topic("pubsub", "orders")]
    public async Task<IActionResult> Subscribe(Order order)
    {
        logger.LogInformation($"Received a new order! Id: {order.Id} Product: {order.Product} Quantity: {order.Quantity} Price: {order.Price} Total: {order.Total:N2}");
        return Ok();
    }
}



public record Order(int Id, string Product, int Quantity, decimal Price)
{
    public decimal Total => Quantity * Price;
}