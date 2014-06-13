using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace EShop.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название товара")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите описание товара")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительную цену")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Пожалуйста, определите категорию товара")]
        public string Category { get; set; }

        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
    }
}