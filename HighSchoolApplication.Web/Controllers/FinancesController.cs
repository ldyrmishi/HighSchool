using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.Web.Factory;
using HighSchoolApplication.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HighSchoolApplication.Web.Controllers
{
    public class FinancesController : Controller
    {
        // GET: Finances
        public  IActionResult Index(FinancesTabViewModel vm)
        {
            if(vm == null)
            {
                vm = new FinancesTabViewModel
                {
                    ActiveTab = Tab.Incomings
                };
            }

            return View(vm);
        }

        public IActionResult SwitchToTabs(string tabname)
        {
            var vm = new FinancesTabViewModel();
            switch (tabname)
            {
                case "Incomings":
                    vm.ActiveTab = Tab.Incomings;
                    break;
                case "Expenses":
                    vm.ActiveTab = Tab.Expenses;
                    break;
                default :
                    vm.ActiveTab = Tab.Incomings;
                    break;

            }
            return RedirectToAction(nameof(FinancesController.Index), vm);
        }
        
    }
}