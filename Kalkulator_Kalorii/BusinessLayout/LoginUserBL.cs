using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kalkulator_Kalorii.DAL;
using Kalkulator_Kalorii.Models;

namespace Kalkulator_Kalorii.BusinessLayout
{
    public class LoginUserBL
    {
        public void CreateUserAccount(LoginUser loginUser)
        {
            DAL_Calculator DAL_calculator = new DAL_Calculator();
            DAL_calculator.UserAccountCreate(loginUser);
        }
        public List<LoginUser> GetAccountList()
        {
            DAL_Calculator DAL_calculator = new DAL_Calculator();
            return DAL_calculator.GetListAccount();
        }
    }
}