using M8E1.Model;
using M8E1.Store;
using Microsoft.AspNetCore.Mvc;

namespace M8E1.Controllers;

public class ProductsController(ProductStore store) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var product = store.GetAll();

        return View(product);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Edit(Guid id)
    {var product = store.GetById(id);
        if(product is null) return NotFound();
        return View(product);
    }

    [HttpGet]
    public IActionResult Delete(Guid id)
    {
        var product = store.GetById(id);
        if(product is null) return NotFound();
        return View(product);
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        product.Id = Guid.NewGuid();
        store.Add(product);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Edit(Product product)
    {
        var success = store.Update(product);
        if(!success) return NotFound();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteProduct(Guid id)
    {
        var product = store.GetById(id);
        if(product is null) return NotFound();
        store.Delete(product);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Details(Guid id)
    {
        var product = store.GetById(id);
        if(product is null) return NotFound();
        return View(product);
    }
}