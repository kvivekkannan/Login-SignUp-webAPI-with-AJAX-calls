using Project01.DAL;
using Project01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project01.Controllers.APIControllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private UnitOfWork _iUoW = new UnitOfWork();

        #region ctor
        public UsersController()
        {
            _iUoW = new UnitOfWork();
        }

        public UsersController(UnitOfWork iUoW)
        {
            this._iUoW = iUoW;
        }
        #endregion       

        public IHttpActionResult GetUsersList()
        {
            return (IHttpActionResult)_iUoW.UserDetailsRepository.GetUserDetails();
        }

        [Route("SignUp")]
        [HttpPost]
        public IHttpActionResult PostSignUp(UserDetails user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _iUoW.UserDetailsRepository.AddUserDetail(user);
            _iUoW.Save();
            ModelState.Clear();
            return Ok();
        }

        
        [Route("Edit")]
        [HttpPost]
        public IHttpActionResult Edit(int id, UserDetails user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid user");
            _iUoW.UserDetailsRepository.EditUserDetails(id, user);
            _iUoW.Save();
            ModelState.Clear();
            return Ok();
            #region commented
            //if (!ModelState.IsValid)
            //    return BadRequest("Not a valid user");
            //else
            //{
            //    if(user != null)
            //    {
            //        _iUoW.Save();
            //    }
            //    else
            //    {
            //        return NotFound();
            //    }
            //}
            ////var existingUser = _iUoW.UserDetailsRepository.GetUserDetailsById(id);
            ////if(existingUser != null)
            ////{
            ////    existingUser.FirstName = user.FirstName;
            ////    existingUser.LastName = user.LastName;
            ////    existingUser.EmailAddress = user.EmailAddress;
            ////    existingUser.UserName = user.UserName;
            ////    existingUser.Password = user.Password;
            ////    existingUser.ConfirmPassword = user.ConfirmPassword;
            ////    existingUser.ContactNumber = user.ContactNumber;

            ////    _iUoW.Save();
            ////}
            ////else
            ////{
            ////    return NotFound();
            ////}
            //return Ok(); 
            #endregion
        }


        [Route("Delete")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid user");
            var user = _iUoW.UserDetailsRepository.GetUserDetailsById(id);
            _iUoW.UserDetailsRepository.RemoveUserDetail(user);
            _iUoW.Save();
            ModelState.Clear();
            return Ok();

            #region commented
            //if (id <= 0)
            //    return BadRequest("Requested user is not a valid account");

            //var delUser = _iUoW.UserDetailsRepository.GetUserDetailsById(id);
            //if (delUser != null)
            //{
            //    _iUoW.UserDetailsRepository.RemoveUserDetail(delUser);
            //    _iUoW.Save();
            //}
            //else
            //{
            //    return NotFound();
            //}
            //return Ok(); 
            #endregion

        }
        //[Route("Login")]
        //[HttpPost]
        //public IHttpActionResult PostLogin(UserDetails user)
        //{
        //    HttpResponseMessage result;
        //    var data = _iUoW.UserDetailsRepository.GetUserLoginDetails(user);
        //    if (data.UserName == user.UserName && data.Password == user.Password)
        //    {
        //        result = Request.CreateResponse(HttpStatusCode.OK, user);
        //        return Ok(_iUoW.UserDetailsRepository.GetUserDetails());
        //    }
        //    else
        //    {
        //        result = Request.CreateResponse(HttpStatusCode.NotFound, user);
        //        return (IHttpActionResult)result;
        //    }
        //}
        //[Route("all")]
        //[HttpPost]
        //public IHttpActionResult GetUsers()
        //{
        //    return Ok(_iUoW.UserDetailsRepository.GetUserDetails());
        //}
        //[HttpGet]
        //public IHttpActionResult GetAllUserDetails()
        //{
        //    var listOfAllUserDetails = _iUoW.UserDetailsRepository.GetUserDetails();
        //    if(listOfAllUserDetails != null)
        //    {
        //        return Ok(listOfAllUserDetails.ToList());
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}
    }

}
