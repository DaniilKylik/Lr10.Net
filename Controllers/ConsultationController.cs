using Lr10.Models;
using Microsoft.AspNetCore.Mvc;
using Lr10.Services;
using System;

namespace Lr10.Controllers
{
    public class ConsultationController : Controller
    {
        private readonly IConsultationService _consultationService;

        public ConsultationController(IConsultationService consultationService)
        {
            _consultationService = consultationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Products = ConsultationForm.Products;
            return View(new ConsultationForm());
        }

        [HttpPost]
        public IActionResult Index(ConsultationForm model)
        {
            ViewBag.Products = ConsultationForm.Products;

            if (_consultationService.ValidateConsultationForm(model, ModelState))
            {
                ViewBag.SuccessMessage = "Ваша консультація зареєстрована!";
                return View(new ConsultationForm()); 
            }

            return View(model); 
        }
    }
}
