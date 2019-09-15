using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.Web.Factory;
using HighSchoolApplication.Web.Models;
using HighSchoolApplication.Web.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HighSchoolApplication.Web.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public async Task<IActionResult> DigitalRegister(int id)
        {
            var response = await HighSchoolApiClientFactory.Instance.GetUsersByClass(id, HttpContext.Session.GetString("Token"));

            var digitalRegister = new DigitalRegisterModel()
            {
                users = response.Data.ToList()
            };

            var daysOfWeek = Helper.Daily(new TimeSpan(12, 0, 0));

            CalendarModel calendar = new CalendarModel();

            digitalRegister.calendar = calendar;

            digitalRegister.calendar.FirstDayOfWeek = daysOfWeek.ElementAt(0);
            digitalRegister.calendar.SecondDayOfWeek = daysOfWeek.ElementAt(1);
            digitalRegister.calendar.ThirdDayOfWeek = daysOfWeek.ElementAt(2);
            digitalRegister.calendar.FourthDayOfWeek = daysOfWeek.ElementAt(3);
            digitalRegister.calendar.FifthDayOfWeek = daysOfWeek.ElementAt(4);

            var registerValueDict = new Dictionary<string, string>();


            foreach (var item in response.Data)
            {
                registerValueDict.Add(item.IdUser.ToString()+ "-" + digitalRegister.calendar.FirstDayOfWeek + "-" + item.ClassId.ToString(), "One");
                registerValueDict.Add(item.IdUser.ToString()+ "-"  + digitalRegister.calendar.SecondDayOfWeek + "-" + item.ClassId.ToString(), "One");
                registerValueDict.Add(item.IdUser.ToString()+ "-"  + digitalRegister.calendar.ThirdDayOfWeek + "-" + item.ClassId.ToString(), "One");
                registerValueDict.Add(item.IdUser.ToString()+ "-"  + digitalRegister.calendar.FourthDayOfWeek + "-" + item.ClassId.ToString(), "One");
                registerValueDict.Add(item.IdUser.ToString() + "-" + digitalRegister.calendar.FifthDayOfWeek + "-" + item.ClassId.ToString(), "One");
            }

            return View(digitalRegister);
        }

        

    }
}