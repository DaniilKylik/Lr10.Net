using Lr10.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Lr10.Services
{
    public interface IConsultationService
    {
        bool ValidateConsultationForm(ConsultationForm model, ModelStateDictionary modelState);
    }

    public class ConsultationService : IConsultationService
    {
        public bool ValidateConsultationForm(ConsultationForm model, ModelStateDictionary modelState)
        {
            bool isValid = true;

            if (model.ConsultationDate <= DateTime.Today)
            {
                modelState.AddModelError("ConsultationDate", "Дата консультації має бути в майбутньому.");
                isValid = false;
            }
            else if (model.ConsultationDate.DayOfWeek == DayOfWeek.Saturday || model.ConsultationDate.DayOfWeek == DayOfWeek.Sunday)
            {
                modelState.AddModelError("ConsultationDate", "Консультації у вихідні дні недоступні.");
                isValid = false;
            }

            if (model.Product == "Основи" && model.ConsultationDate.DayOfWeek == DayOfWeek.Monday)
            {
                modelState.AddModelError("ConsultationDate", "Консультації за продуктом 'Основи' не можуть проходити по понеділках.");
                isValid = false;
            }

            return isValid;
        }
    }
}
