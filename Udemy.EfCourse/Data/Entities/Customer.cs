using System.ComponentModel.DataAnnotations;

namespace Udemy.EfCourse.Data.Entities
{
    public class Customer
    {
        [Key]
        public int Number { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

}
