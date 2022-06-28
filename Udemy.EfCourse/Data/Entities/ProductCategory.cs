namespace Udemy.EfCourse.Data.Entities
{

    public class ProductCategory
    {
        public int ProductID { get; set; }

        public Product Product { get; set; }

        public int CategoryID { get; set; }

        public Category Category { get; set; }

    }
}
