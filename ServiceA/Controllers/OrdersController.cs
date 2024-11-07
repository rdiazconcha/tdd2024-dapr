using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace ServiceA.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController(DaprClient daprClient) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostAsync(Order order)
    {
        await daprClient.PublishEventAsync(
                                        "pubsub",
                                        "orders",
                                        order);
        return Ok(order);
    }
}


public record Order(int Id, string Product, int Quantity, decimal Price);