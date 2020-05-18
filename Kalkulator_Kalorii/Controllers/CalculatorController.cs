using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kalkulator_Kalorii.Models;
using Kalkulator_Kalorii.BusinessLayout;
using Kalkulator_Kalorii.ViewModels;

namespace Kalkulator_Kalorii.Controllers
{
    [Authorize]
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public ActionResult CalculatorBMI()
        {
            UserBMI user = new UserBMI();
            return View(user);
        }

        [HttpPost]
        public ActionResult CalculatorBMI(UserBMI user)
        {
            if (ModelState.IsValid)
            {
                user.bmi = user.weight / (user.growth * user.growth);
                return View("ResultBMI", user);
            }
            else
            {
                return View(user);
            }
        }

        public ActionResult CalculatorPPM()
        {
            UserPPM user = new UserPPM();
            return View(user);
        }

        [HttpPost]
        public ActionResult CalculatorPPM(UserPPM user)
        {
            if (ModelState.IsValid)
            {
                if (user.gender == _gender.kobieta)
                {
                    user.ppm = 655.1f + (9.563f * user.weight) + (1.85f * user.growth) - (4.676f * user.age);
                }
                else
                {
                    user.ppm = 66.5f + (13.75f * user.weight) + (5.003f * user.growth) - (6.775f * user.age);
                }
                return View("ResultPPM", user);
            }
            else
            {
                return View(user);
            }
        }

        public ActionResult CalculatorLorentz()
        {
            UserLorentz userLorentz = new UserLorentz();
            return View(userLorentz);
        }
        [HttpPost]
        public ActionResult CalculatorLorentz(UserLorentz user)
        {
            if (ModelState.IsValid)
            {
                if(user.gender == _gender.kobieta)
                {
                    user.lorentz = user.growth - 100 - ((user.growth - 150) / 2);
                }
                else
                {
                    user.lorentz = user.growth - 100 - ((user.growth - 150) / 4);
                }
                return View("ResultLorentz", user);
            }
            else
            {
                return View(user);
            }
        }


    }
    
}