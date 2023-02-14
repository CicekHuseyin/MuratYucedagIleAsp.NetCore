using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore.Controllers
{
    public class RegisterController : Controller
    {
        
        WriterManager wm = new WriterManager(new EfWriterRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p)
        {
            
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(p);
            if (results.IsValid)
            {
                TempData["Success"] = true;
                p.WriterStatus = true;
                p.WriterAbout = "Deneme testi";
                wm.WriterAdd(p);
                return RedirectToAction("Index","Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(); 
           
        }

    }
    //public class RegisterBindingModel
    //{
    //    [Required]
    //    [DataType(DataType.Password)]
    //    [Display(Name = "WriterPassword")]
    //    public string WriterPassword
    //    {
    //        get;
    //        set;
    //    }

    //    [DataType(DataType.Password)]
    //    [Display(Name = "ConfirmPassword")]
    //    [Compare(nameof(WriterPassword), ErrorMessage = "Şifre ve onay şifresi eşleşmiyor.")]
    //    public string ConfirmPassword
    //    {
    //        get;
    //        set;
    //    }

    //    // remaining required properties
    //}
}
