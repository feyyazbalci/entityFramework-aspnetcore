namespace Udemy.EfCourse.Data.Entities
{
    public class ProductDetail
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
