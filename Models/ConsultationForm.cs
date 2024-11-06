using System;
using System.ComponentModel.DataAnnotations;

namespace Lr10.Models
{
    public class ConsultationForm
    {
        [Required(ErrorMessage = "Ім'я та прізвище є обов'язковим")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email є обов'язковим")]
        [EmailAddress(ErrorMessage = "Неправильний формат Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Будь ласка, виберіть дату")]
        [DataType(DataType.Date)]
        public DateTime ConsultationDate { get; set; }

        [Required(ErrorMessage = "Виберіть продукт для консультації")]
        public string Product { get; set; }

        public static readonly string[] Products = { "JavaScript", "C#", "Java", "Python", "Основи" };
    }
}
