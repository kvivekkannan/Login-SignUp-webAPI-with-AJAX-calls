using Project01.DAL;
using Project01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Project01.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork _unitOfWork = new UnitOfWork(new LoginDbContext());

        string apiBaseAddress = "https://localhost:44328/api/";
        public ActionResult Index()
        {
            return View(_unitOfWork.UserDetailsRepository.GetUserDetails());
        }
        
        public ActionResult LoginOrSignUp()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var user = _unitOfWork.UserDetailsRepository.GetUserDetailsById(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult EditUser(UserDetails user)
        {
            var id = user.UserId;
            //_unitOfWork.UserDetailsRepository.EditUserDetails(id, user);
            //_unitOfWork.Save();
            var existingUser = _unitOfWork.UserDetailsRepository.GetUserDetailsById(id);
            if (user != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.EmailAddress = user.EmailAddress;
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;
                existingUser.ConfirmPassword = user.ConfirmPassword;
                existingUser.ContactNumber = user.ContactNumber;
                _unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            var user = _unitOfWork.UserDetailsRepository.GetUserDetailsById(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult DeleteUser(UserDetails user)
        {
            var id = user.UserId;
            //var detail = _unitOfWork.UserDetailsRepository.GetUserDetailsById(id);
            _unitOfWork.UserDetailsRepository.RemoveUserDetailById(id);
            return RedirectToAction("Index");
        }



        #region Edit
        //[Route("Home/Edit/{id}")]
        //[HttpPost]
        //public ActionResult Edit(UserDetails user)
        //{
        //    using (var editUser = new HttpClient())
        //    {
        //        editUser.BaseAddress = new Uri(apiBaseAddress);

        //        var editTask = editUser.PostAsJsonAsync<UserDetails>("Edit", user);
        //        editTask.Wait();

        //        var result = editTask.Result;
        //        if (result.IsSuccessStatusCode)
        //            return RedirectToAction("Index", "Home");
        //    }
        //    return View(user);
        //}
        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    var user = _unitOfWork.UserDetailsRepository.GetUserDetailsById(id);
        //    return View(user);
        //    #region commented
        //    //UserDetails user = null;
        //    //using (var editUser = new HttpClient())
        //    //{
        //    //    editUser.BaseAddress = new Uri("https://localhost:44328/api/userDetails/");

        //    //    var editTask = editUser.GetAsync("Edit/" + id.ToString());
        //    //    editTask.Wait();

        //    //    var result = editTask.Result;
        //    //    if (result.IsSuccessStatusCode)
        //    //    {
        //    //        var readTask = result.Content.ReadAsAsync<UserDetails>();
        //    //        readTask.Wait();
        //    //        user = readTask.Result;
        //    //    }
        //    //}
        //    //return View(user); 
        //    #endregion
        //} 
        #endregion

        #region delete
        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    return View(_unitOfWork.UserDetailsRepository.GetUserDetailsById(id));
        //}

        //[Route("Home/Delete/{id}")]
        //[HttpDelete]
        //public ActionResult Delete(int id, UserDetails user)
        //{
        //    //_unitOfWork.UserDetailsRepository.RemoveUserDetail(user);
        //    using (var deleteUser = new HttpClient())
        //    {
        //        deleteUser.BaseAddress = new Uri(apiBaseAddress);

        //        var deleteTask = deleteUser.DeleteAsync("Delete/" + id.ToString());
        //        deleteTask.Wait();

        //        var result = deleteTask.Result;
        //        if (result.IsSuccessStatusCode)
        //            return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");
        //} 
        #endregion

        #region commented
        //public ActionResult Insert()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Insert(UserDetails user)
        //{
        //    _unitOfWork.UserDetailsRepository.InsertUserDetails(user);
        //    _unitOfWork.Save();
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public ActionResult Edit(int id, UserDetails details)
        //{
        //    _unitOfWork.UserDetailsRepository.EditUserDetails(id, details);
        //    _unitOfWork.Save();
        //    return RedirectToAction("Index");
        //} 

        //public ActionResult Delete(int id)
        //{
        //    return View(_unitOfWork.UserDetailsRepository.GetUserDetailsById(id));
        //}

        //[HttpPost]
        //public ActionResult Delete(int id, UserDetails user)
        //{
        //    _unitOfWork.UserDetailsRepository.RemoveUserDetail(user);
        //    _unitOfWork.Save();
        //    return RedirectToAction("Index");

        //}
        //public ActionResult Edit(UserDetails user)
        //{
        //    using (var editUser = new HttpClient())
        //    {
        //        editUser.BaseAddress = new Uri("https://localhost:44328/api/users/");

        //        var editTask = editUser.PutAsJsonAsync("Edit", user);
        //        editTask.Wait();

        //        var result = editTask.Result;
        //        if (result.IsSuccessStatusCode)
        //            return RedirectToAction("Index");
        //    }
        //    return View(user);
        //}
        //public ActionResult Edit(int id)
        //{
        //    return View(_unitOfWork.UserDetailsRepository.GetUserDetailsById(id));
        //    //return View(_unitOfWork.UserDetailsRepository.GetUserDetailsById(id));
        //}
        //[HttpPost]
        #endregion

    }


}