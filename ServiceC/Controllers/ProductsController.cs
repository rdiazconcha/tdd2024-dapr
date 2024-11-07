using Microsoft.AspNetCore.Mvc;

namespace ServiceC.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet] // <-- /products
    public async Task<IActionResult> Get()
    {
        var list = new List<Product>();
        list.Add(new Product(1, 10, "Apple", 1.99m));
        list.Add(new Product(2, 20, "Banana", 2.99m));
            list.Add(new Product(3, 30, "Cherry", 3.99m));
            return Ok(list);    
    }
}

public record Product(int Id, int SupplierId, string Name, decimal Price);