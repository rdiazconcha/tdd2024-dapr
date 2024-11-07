using   Dapr.Client;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;

namespace ServiceAggregator.Controllers;

[ApiController]
[Route("[controller]")]
public class QueryController(DaprClient daprClient) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        
        var products = await daprClient.InvokeMethodAsync<IEnumerable<Product>>("servicec", "products");
        var suppliers = await daprClient.InvokeMethodAsync<IEnumerable<Supplier>>("serviced", "suppliers");

        return Ok(new
        {
            //Products = products,
            Suppliers = suppliers
        });
    }
}

public record Product(int Id, int SupplierId, string Name, decimal Price);

public record Supplier(int Id, string Name);