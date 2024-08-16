using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private static List<Product> Products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Price = 999.99M },
        new Product { Id = 2, Name = "Phone", Price = 499.99M }
    };

    // GET: api/products
    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(Products);
    }

    // GET: api/products/{id}
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    // POST: api/products
    [HttpPost]
    public IActionResult CreateProduct(Product product)
    {
        product.Id = Products.Count + 1;
        Products.Add(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    // PUT: api/products/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, Product updatedProduct)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();

        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;

        return NoContent();
    }

    // DELETE: api/products/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();

        Products.Remove(product);
        return NoContent();
    }
}
