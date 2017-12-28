using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class PurchaseInfo
    {
        [Required]
        [DataType(DataType.CreditCard)]
        [Display(Name = "Номер карты")]
        public string CardNumber { get; set; }

        [Required]
        [Display(Name = "Год окончания действия карты")]
        public int ExpYear { get; set; }

        [Required]
        [Display(Name = "Месяц окончания действия карты")]
        public int ExpMonth { get; set; }

        [Required]
        [Display(Name = "Имя держателя карты")]
        public string CardHolder { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(3)]
        [MaxLength(3)]
        [Display(Name = "Код безопасности CVC")]
        public string CVC { get; set; }

        [Display(Name = "Сумма покупки")]
        public decimal Sum { get; set; }
    }
}