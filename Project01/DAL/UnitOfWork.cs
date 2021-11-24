using Project01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project01.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LoginDbContext loginDb;
        public UnitOfWork()
        {
            loginDb = new LoginDbContext();
        }

        public UnitOfWork(LoginDbContext loginDb)
        {
            this.loginDb = loginDb;
        }

        private IUserDetailsRepository _userDetails;
        public IUserDetailsRepository UserDetailsRepository
        {
            get
            {
                if(this._userDetails == null)
                {
                    this._userDetails = new UserDetailsRepository(loginDb);
                }
                return this._userDetails;
            }
            
        }

        public int Save()
        {
            return loginDb.SaveChanges();
            //throw new NotImplementedException();
        }


        #region Dispose method
        private bool disposedValue;       

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
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