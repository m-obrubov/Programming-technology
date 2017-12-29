using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace OnlineShop.Models
{
    public enum OrderStatus : short
    {
        [Display(Name = "Создан")]
        Created,
        [Display(Name = "Подтвержден")]
        Confirmed,
        [Display(Name = "Оплачен")]
        Payed,
        [Display(Name = "Доставляется")]
        Delivering,
        [Display(Name = "Завершен")]
        Done,
        [Display(Name = "Отклонен")]
        Cancelled
    }

    public enum PaymentType : short
    {
        [Display(Name = "Наличная")]
        Cash,
        [Display(Name = "Безналичная")]
        Cashless
    }

    public static class Extensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
                where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }
    }
}