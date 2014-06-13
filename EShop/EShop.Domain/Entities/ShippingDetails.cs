using System.ComponentModel.DataAnnotations;

namespace EShop.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Пожалуйста, введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите адрес в первое поле")]
        public string Line1 { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите город")]
        public string City { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите область")]
        public string State { get; set; }
        public string Zip { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите страну")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}