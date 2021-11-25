using Project01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project01.DAL
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        private LoginDbContext dbcon;

        public UserDetailsRepository(LoginDbContext dbcon)
        {
            this.dbcon = dbcon;
        }

        public void AddUserDetail(UserDetails user)
        {
            dbcon.userdetails.Add(user);
           // throw new NotImplementedException();
        }        

        public IEnumerable<UserDetails> GetUserDetails()
        {
            return dbcon.userdetails.ToList();
            //throw new NotImplementedException();
        }

        public UserDetails GetUserDetailsById(int id)
        {
            return dbcon.userdetails.Find(id);
            //throw new NotImplementedException();
        }

        public void RemoveUserDetail(UserDetails user)
        {
            dbcon.userdetails.Remove(user);
            //throw new NotImplementedException();
        }
        public void RemoveUserDetailById(int id)
        {
            var user = dbcon.userdetails.Find(id);
            dbcon.userdetails.Remove(user);
            dbcon.SaveChanges();
            //throw new NotImplementedException();
        }

        //public void SaveUserDetails()
        //{
        //    dbcon.SaveChanges();
        //    //throw new NotImplementedException();
        //}

        public void UpdateUserDetails(UserDetails allUserDetails)
        {
            dbcon.Entry(allUserDetails).State = System.Data.Entity.EntityState.Modified;
            //throw new NotImplementedException();
        }
        public UserDetails GetUserLoginDetails(UserDetails user)
        {
            return dbcon.userdetails.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
            //return dbcon.userdetails.Find(username,password);
            //throw new NotImplementedException();
        }

        public UserDetails EditUserDetails(int id, UserDetails userDetails)
        {
            var user = dbcon.userdetails.Find(id);
            if(user != null)
            {
                user.FirstName = userDetails.FirstName;
                user.LastName = userDetails.LastName;
                user.EmailAddress = userDetails.EmailAddress;
                user.UserName = userDetails.UserName;
                user.Password = userDetails.Password;
                user.ConfirmPassword = userDetails.ConfirmPassword;
                user.ContactNumber = userDetails.ContactNumber;
            }
            return user;
        }

        public UserDetails InsertUserDetails(UserDetails detail)
        {
            return dbcon.userdetails.Add(detail);            
        }

        #region dispose method


        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    dbcon.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UserDetailsRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }        
        #endregion
    }
}