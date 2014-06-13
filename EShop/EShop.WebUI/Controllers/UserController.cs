using EShop.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SimpleLogInSystem.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Models.UserModel user)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(user.Email, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("","Информация для входа не верная. Проверьте введенные данные.");
                }

            }

            return View(user);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Models.UserModel user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new EFDbContext())
                {
                    /*
                    var crypto = new SimpleCrypto.PBKDF2();

                    var encrpPass = crypto.Compute(user.Password);

                    var sysUser = db.Users.Create();

                    sysUser.Email = user.Email;
                    sysUser.Password = encrpPass;
                    sysUser.PasswordSalt = crypto.Salt;
                    sysUser.UserId = Guid.NewGuid();

                    db.Users.Add(sysUser);
                    db.SaveChanges();
                    */
                    return RedirectToAction("Index", "Home");
                }

            }
            return View(user);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        private bool IsValid(string email, string password)
        {
           /* var crypto = new SimpleCrypto.PBKDF2();

            bool isValid = false;

            using (var db = new EFDbContext())
            {
                var user = db.SystemUsers.FirstOrDefault(u => u.Email == email);

                    if (user != null)
                    {
                        if(user.Password == crypto.Compute(password, user.PasswordSalt))
                        {
                            isValid = true;
                        }
                    }
            }
            */

            throw new NotImplementedException();
            //return isValid;
        }

    }
}
