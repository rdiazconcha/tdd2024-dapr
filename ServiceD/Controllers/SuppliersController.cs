using Microsoft.AspNetCore.Mvc;

namespace ServiceD.Controllers;

[ApiController]
[Route("[controller]")]
public class SuppliersController : ControllerBase
{
    [HttpGet] // <-- /suppliers
   public async Task<IActionResult> Get()
    {
        var list = new List<Supplier>();
        list.Add(new Supplier(1, "Supplier A"));
        list.Add(new Supplier(2, "Supplier B"));
        list.Add(new Supplier(3, "Supplier C"));
        return Ok(list);
    }
}

public record Supplier(int Id, string Name);