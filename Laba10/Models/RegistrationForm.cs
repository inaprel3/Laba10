using System.ComponentModel.DataAnnotations;

namespace Laba10.Models
{
    public class RegistrationForm
    {
        [Required(ErrorMessage = "Поле 'Ім'я прізвище' є обов'язковим")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле 'Email' є обов'язковим")]
        [EmailAddress(ErrorMessage = "Введіть коректний Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле 'Бажана дата консультації' є обов'язковим")]
        [FutureDate(ErrorMessage = "Дата має бути у майбутньому")]
        public DateTime ConsultationDate { get; set; }

        [Required(ErrorMessage = "Виберіть продукт")]
        public string SelectedProduct { get; set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                return date.Date > DateTime.Now.Date && date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
            }
            return false;
        }
    }
}