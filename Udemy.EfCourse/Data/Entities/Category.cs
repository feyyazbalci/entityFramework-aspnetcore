using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.EfCourse.Data.Entities
{

    //tablo ismi degistirmek istersek [Table(name:"KategoriTablo")]
    public class Category
    {
        [Column("category_id")]
        public int ID { get; set; }

        [Required]
        [Column("category_name",TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        public List<ProductCategory> ProductCategories { set; get; }
    }
}
