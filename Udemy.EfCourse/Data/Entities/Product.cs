using System;
using System.Collections.Generic;

namespace Udemy.EfCourse.Data.Entities
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<SaleHistory> SalesHistory { get; set; }

        public ProductDetail ProductDetail { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
