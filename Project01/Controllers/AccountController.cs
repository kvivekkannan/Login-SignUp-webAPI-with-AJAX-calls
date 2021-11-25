using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project01.Models;
using Project01.DAL;
using System.Net.Http;

namespace Project01.Controllers
{
    public class AccountController : Controller
    {
        //private IUserDetailsRepository UserDetailsRepository;
        UnitOfWork _unitOfWork = new UnitOfWork(new LoginDbContext());

        public AccountController()
        {
            //this.UserDetailsRepository = new UserDetailsRepository(new LoginDbContext());
            this._unitOfWork = new UnitOfWork(new LoginDbContext());
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        //  GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();            
        }

        [HttpPost]
        public ActionResult SignUp(UserDetails user)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.UserDetailsRepository.AddUserDetail(user);
                _unitOfWork.Save();
                ModelState.Clear();
                #region commented
                //using (var newUser = new HttpClient())
                //{
                //    newUser.BaseAddress = new Uri("https://localhost:44328/api/userDetails/");

                //    var postTask = newUser.PostAsJsonAsync<UserDetails>("PostUserDetails", user);
                //    postTask.Wait();
                //    var result = postTask.Result;
                //    if (result.IsSuccessStatusCode)
                //    {
                //        return RedirectToAction("Index", "Home");
                //    }
                //}
                //ModelState.AddModelError(string.Empty, "Data/Server error. Try again"); 
                #endregion
            }
            return RedirectToAction("Index", "Home");
            //return View(user);
        }

        [HttpPost]
        public ActionResult Login(UserDetails user)
        {            
            var loginCheck = _unitOfWork.UserDetailsRepository.GetUserLoginDetails(user);
            if (loginCheck != null)
            {

                Session["UserId"] = user.UserId;
                Session["Username"] = user.UserName;
                return RedirectToAction("UserProfile", user);
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is wrong. Please try again");
            }
            return View();
        }

        public ActionResult UserProfile()
        {
            if (Session["UserId"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Logout(UserDetails user)
        {
            Session.Abandon();
            return RedirectToAction("LoginOrSignUp", "Home");
        }




        #region DEFAULT
        //// GET: Account
        //public ActionResult Index()
        //{
        //    return View();
        //}

        ////  GET: Account/Login
        //public ActionResult Login()
        //{
        //    return View();
        //}

        //public ActionResult SignUp()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult SignUp(UserDetails user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (LoginDbContext dbc = new LoginDbContext())
        //        {
        //            dbc.userdetails.Add(user);
        //            dbc.SaveChanges();
        //        }
        //        ModelState.Clear();
        //        ViewBag.Message = user.FirstName + " " + user.LastName + " user has been successfully registered.";
        //    }
        //    return View();
        //}


        //[HttpPost]
        //public ActionResult Login(UserDetails user)
        //{
        //    using (LoginDbContext lDb = new LoginDbContext())
        //    {
        //        #region individualcheckAttempt
        //        //var usernameCheck = lDb.userdetails.SingleOrDefault(uName => uName.UserName == user.UserName);
        //        //var passwordCheck = lDb.userdetails.SingleOrDefault(uPassword => uPassword.Password == user.Password);

        //        //if(usernameCheck != null)
        //        //{
        //        //    ModelState.AddModelError("", "Username entered is wrong.");
        //        //    return View();
        //        //}
        //        //else if(passwordCheck != null)
        //        //{
        //        //    ModelState.AddModelError("", "Password entered is wrong.");
        //        //    return View();
        //        //}
        //        //else
        //        //{
        //        //    Session["UserId"] = user.UserId;
        //        //    Session["Username"] = user.UserName;
        //        //    return RedirectToAction("UserProfile", user);
        //        //} 
        //        #endregion

        //        var loginCheck = lDb.userdetails.SingleOrDefault(usr => usr.UserName == user.UserName && usr.Password == user.Password);
        //        if (loginCheck != null)
        //        {
        //            Session["UserId"] = user.UserId;
        //            Session["Username"] = user.UserName;
        //            return RedirectToAction("UserProfile", user);
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Username or Password is wrong. Please try again");
        //        }
        //    }
        //    return View();
        //}

        //public ActionResult UserProfile()
        //{
        //    if (Session["UserId"] != null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }
        //}

        //public ActionResult Logout(UserDetails user)
        //{
        //    Session.Abandon();
        //    return RedirectToAction("LoginOrSignUp", "Home");
        //}

        #endregion
    }
}