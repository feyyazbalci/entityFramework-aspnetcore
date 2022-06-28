using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Udemy.EfCourse.Data.Contexts;
using Udemy.EfCourse.Data.Entities;

namespace Udemy.EfCourse.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            UdemyContext context = new();
            //context.Products.Add(new Data.Entities.Product
            //{
            //    Name = "Telefon",
            //    Price = 1230
            //});
            //context.SaveChanges();

            //var updatedProduct = context.Products.Find(1);
            //updatedProduct.Price = 1000;
            //context.Products.Update(updatedProduct);
            //context.SaveChanges();

            //var deletedProduct = context.Products.FirstOrDefault(p => p.ID == 2);
            //context.Products.Remove(deletedProduct);
            //context.SaveChanges(true);

            Product product = new Product();
            product.Price = 1250;
            context.Products.Add(product);
            context.SaveChanges();

            return View();
        }
    }
}
