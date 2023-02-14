using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccesLayer.Abstract;

namespace Asp.NetCore.ViewComponents.Category
{
    public class CategoryList: ViewComponent
    {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            public IViewComponentResult Invoke()
            {
                var values = cm.GetList();
                return View(values);
            }
    }
}
