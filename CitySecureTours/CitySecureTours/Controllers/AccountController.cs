using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CityToursMVC.Models; //Add 
using System.Web.Security; //Add 
using CitySecureTours.Data;//Add - comes from the data folder!!!

namespace CityToursMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(UserModel model, string returnUrl) //Add Code 
        {
            if (ModelState.IsValid)
            {
                using (ToursContainer1 entities = new ToursContainer1())
                {
                    string username = model.Username;
                    //string password = PasswordSecurity.PasswordStorage.CreateHash(model.Password).Hash; 


                    // Now if our password was enctypted or hashed we would have done the 
                    // same operation on the user entered password here, But for now 
                    // since the password is in plain text lets just authenticate directly 


                    var user = entities.UserAccounts.FirstOrDefault(x => x.Username == username);


                    bool userValid = false;


                    if (user != null)
                    {
                        userValid = PasswordSecurity.PasswordStorage.VerifyPassword(model.Password, user.Password, user.Salt);
                    }


                    // User found in the database 
                    if (userValid)
                    {


                        FormsAuthentication.SetAuthCookie(username, false);
                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    }
                }
            }


            return View(model);
        }


        public ActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Username != null && model.Password != null)
                {
                    ToursContainer1 context = new ToursContainer1();
                    UserAccount ua = new UserAccount();


                    PasswordSecurity.SecuredPassword password = PasswordSecurity.PasswordStorage.CreateHash(model.Password);
                    ua.Username = model.Username;
                    ua.Password = password.Hash;
                    ua.Salt = password.Salt;
                    ua.Createdate = DateTime.Now;
                    ua.RoleId = 1;


                    context.UserAccounts.Add(ua);
                    context.SaveChanges();


                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();


            return RedirectToAction("Index", "Home");
        }

    }
}