using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models;

namespace ProductCatalog.Controllers;

public class ProductController : Controller
{
    private static readonly List<Product> Products = new()
    {
        new() { Id = 1, Name = "iPhone 15", Price = 349990, Category = "Смартфон", IsAvailable = true },
        new() { Id = 2, Name = "Samsung Galaxy S24", Price = 399990, Category = "Смартфон", IsAvailable = true },
        new() { Id = 3, Name = "MacBook Air M3", Price = 599990, Category = "Ноутбук", IsAvailable = true },
        new() { Id = 4, Name = "ASUS VivoBook", Price = 289990, Category = "Ноутбук", IsAvailable = false },
        new() { Id = 5, Name = "AirPods Pro", Price = 119990, Category = "Аксессуар", IsAvailable = true },
        new() { Id = 6, Name = "Logitech MX Master", Price = 54990, Category = "Аксессуар", IsAvailable = false }
    };

    public IActionResult Index(string? category)
    {
        var categories = Products.Select(p => p.Category).Distinct().OrderBy(x => x).ToList();
        ViewBag.Categories = categories;
        ViewBag.SelectedCategory = category ?? "Барлығы";
        ViewBag.Title = "Тауарлар каталогы";
        ViewData["Subtitle"] = "Өзіңізге қажетті техниканы таңдаңыз";

        IEnumerable<Product> result = Products;
        if (!string.IsNullOrWhiteSpace(category))
            result = result.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));

        return View(result.ToList());
    }
}
