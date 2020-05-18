using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kalkulator_Kalorii.Models;
using Kalkulator_Kalorii.BusinessLayout;
using Kalkulator_Kalorii.HashPassword;
using System.Web.Security;
using Kalkulator_Kalorii.ViewModels;

namespace Kalkulator_Kalorii.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            AccountListVM accountListVM = new AccountListVM();
            LoginUserBL loginUserBL = new LoginUserBL();
            accountListVM.accountListVM = AccountList2AccountVMList(loginUserBL.GetAccountList());
            return View(accountListVM);
        }

        private List<LoginUserVM> AccountList2AccountVMList(List<LoginUser> accountList)
        {
            List<LoginUserVM> accountVMList = new List<LoginUserVM>();

            foreach (LoginUser account in accountList)
            {
                LoginUserVM accountVM = new LoginUserVM();
                accountVM.loginUserVM = account;
                accountVMList.Add(accountVM);
            }


            return accountVMList;
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(LoginUser account)
        {
            if (ModelState.IsValid)
            {
                LoginUserBL loginUserBL = new LoginUserBL();
                loginUserBL.CreateUserAccount(account);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUser account, string ReturnUrl)
        {
            if (account.username != null && account.password != null)
            {
                LoginUserBL loginUserBL = new LoginUserBL();
                List<LoginUser> accountList = loginUserBL.GetAccountList();
                Hashing hashing = new Hashing();
                LoginUser user = accountList.Where(u => u.username == account.username).Single();
                if (user != null && hashing.VerifyMd5Hash(account.password, user.password))
                {
                    FormsAuthentication.SetAuthCookie(user.username, false);
                    Session["LoginID"] = user.LoginID.ToString();
                    Session["username"] = user.username.ToString();
                    if (ReturnUrl == null)
                    {
                        return RedirectToAction("Home", "Home");
                    }
                    return Redirect(ReturnUrl);
                }
                return View();
            }
            return View(account);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["LoginID"] = null;
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Login");
        }
    }
}